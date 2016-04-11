using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Vault
{
    public class SystemTrayContext : ApplicationContext
    {
        readonly NotifyIcon _notifyIcon;
        readonly Vault _vault;

        public SystemTrayContext()
        {
            var assembly = Assembly.GetEntryAssembly();

            var components = new Container();
            _notifyIcon = new NotifyIcon(components)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = Icon.ExtractAssociatedIcon(assembly.Location),
                Text = assembly.GetName().Name,
                Visible = true
            };

            _notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            _notifyIcon.DoubleClick += notifyIcon_DoubleClick;

            _notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());

            CreateMenuItem("&Exit", (sender, args) => Application.Exit());


            _vault = new Vault();
            _vault.Start();
        }

        void CreateMenuItem(string text, EventHandler toolStripMenuItemOnClick)
        {
            var toolStripMenuItem = new ToolStripMenuItem(text);
            toolStripMenuItem.Click += toolStripMenuItemOnClick;

            _notifyIcon.ContextMenuStrip.Items.Add(toolStripMenuItem);
        }

        static void notifyIcon_DoubleClick(object sender, EventArgs e)
        {

        }

        static void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _vault.Stop();

                var notifyIcon = _notifyIcon;

                notifyIcon.Visible = false;

                notifyIcon.ContextMenuStrip.Opening -= ContextMenuStrip_Opening;
                notifyIcon.DoubleClick -= notifyIcon_DoubleClick;
                notifyIcon.Dispose();
            }
        }
    }
}
