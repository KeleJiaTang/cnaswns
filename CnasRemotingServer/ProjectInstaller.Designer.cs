namespace CnasRemotingServer
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.CnasRemotingServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.CnasRemotingService = new System.ServiceProcess.ServiceInstaller();
            // 
            // CnasRemotingServiceProcessInstaller
            // 
            this.CnasRemotingServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.CnasRemotingServiceProcessInstaller.Password = null;
            this.CnasRemotingServiceProcessInstaller.Username = null;
            // 
            // CnasRemotingService
            // 
            this.CnasRemotingService.DelayedAutoStart = true;
            this.CnasRemotingService.Description = "自动启动CnasRemoting";
            this.CnasRemotingService.DisplayName = "CnasRemotingService";
            this.CnasRemotingService.ServiceName = "CnasRemotingService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.CnasRemotingServiceProcessInstaller,
            this.CnasRemotingService});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller CnasRemotingServiceProcessInstaller;
        public System.ServiceProcess.ServiceInstaller CnasRemotingService;
    }
}