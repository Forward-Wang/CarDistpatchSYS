using System;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Registrator;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DS.MSClient.UIControl
{
    /// <summary>
    /// ���Զ����ֶ�GridControl�ؼ�
    /// 1�����Ӽ��ء�����grid��ʽ����
    /// 2��Я���Զ����ֶ��У�������չ
    /// </summary>
    [System.ComponentModel.DesignerCategory("")]
    [ToolboxItem(true)]
    public class CFGridControl : CGridControl
    {
        
		protected override BaseView CreateDefaultView() {
             
            return CreateView("CGridView");
		}
		protected override void RegisterAvailableViewsCore(InfoCollection collection) {
			base.RegisterAvailableViewsCore(collection);
			collection.Add(new CGridViewInfoRegistrator());
        } 
    }
}
