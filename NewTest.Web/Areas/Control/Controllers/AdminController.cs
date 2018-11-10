using NewTest.Core;
using System.Web.Mvc;
using NewTest.Core.General;
using NewTest.Web.Areas.Control.Models;
using System;
using NewTest.Core.Types;
using System.Collections.Generic;

namespace NewTest.Web.Areas.Control.Controllers
{
    public class AdminController : Controller
    {
        private AdministratorManager adminManager = new AdministratorManager();

        // GET: Control/Admin
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                string _passowrd = Security.Sha256(loginViewModel.Password);
                var _response = adminManager.Verify(loginViewModel.Accounts, _passowrd);
                if (_response.Code == 1)
                {
                    var _admin = adminManager.Find(loginViewModel.Accounts);
                    Session.Add("AdminID", _admin.AdministratorID);
                    Session.Add("Accounts", _admin.Accounts);
                    _admin.LoginTime = DateTime.Now;
                    _admin.LoginIP = Request.UserHostAddress;
                    adminManager.Update(_admin);
                    return RedirectToAction("Index", "Home");
                }
                else if (_response.Code == 2) ModelState.AddModelError("Accounts", _response.Message);
                else if (_response.Code == 3) ModelState.AddModelError("Password", _response.Message);
                else ModelState.AddModelError("", _response.Message);
            }
            return View(loginViewModel);
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        /// <summary>
        /// 管理员列表
        /// </summary>
        /// <returns></returns>
        public JsonResult ListJson()
        {
            return Json(adminManager.FindList());
        }

        /// <summary>
        /// 添加【分部视图】
        /// </summary>
        /// <returns></returns>
        public PartialViewResult AddPartialView()
        {
            return PartialView();
        }

        /// <summary>
        /// 删除 
        /// Response.Code:1-成功，2-部分删除，0-失败
        /// Response.Data:删除的数量
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteJson(List<int> ids)
        {
            int _total = ids.Count;
            Response _res = new Core.Types.Response();
            int _currentAdminID = int.Parse(Session["AdminID"].ToString());
            if (ids.Contains(_currentAdminID))
            {
                ids.Remove(_currentAdminID);
            }
            _res = adminManager.Delete(ids);
            if (_res.Code == 1 && _res.Data < _total)
            {
                _res.Code = 2;
                _res.Message = "共提交删除" + _total + "名管理员,实际删除" + _res.Data + "名管理员。\n原因：不能删除当前登录的账号";
            }
            else if (_res.Code == 2)
            {
                _res.Message = "共提交删除" + _total + "名管理员,实际删除" + _res.Data + "名管理员。";
            }
            return Json(_res);
        }

        /// <summary>
        /// 重置密码【Ninesky】
        /// </summary>
        /// <param name="id">管理员ID</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ResetPassword(int id)
        {
            string _password = "Ninesky";
            Response _resp = adminManager.ChangePassword(id, Security.Sha256(_password));
            if (_resp.Code == 1) _resp.Message = "密码重置为：" + _password;
            return Json(_resp);
        }


        /// <summary>
        /// 我的资料
        /// </summary>
        /// <returns></returns>
        public ActionResult MyInfo()
        {
            return View(adminManager.Find(Session["Accounts"].ToString()));
        }

    }
}