using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnas.wns
{
    class MyContext : SplashScreenApplicationContext
    {

        /// <summary>
        /// 设置启动前的欢迎窗体
        /// </summary>
        protected override void OnCreateSplashScreenForm()
        {
            try
            {
                this.SplashScreenForm = new Login();//启动窗体 
            }
            catch (Exception ex)
            {
            }
            
        }


       /// <summary>
       /// 设置需要启动的主状体
       /// </summary>
        protected override void OnCreateMainForm()
        {
            this.PrimaryForm = new frmLogin();//主窗体 
        }

        /// <summary>
        /// 设置启动窗体等待多少秒
        /// </summary>
        protected override void SetSeconds()
        {
            this.SecondsShow = 5;//启动窗体显示的时间(秒) 
        }
    }
}
