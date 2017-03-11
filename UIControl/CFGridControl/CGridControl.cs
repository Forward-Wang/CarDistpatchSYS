using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DS.MSClient.Controls;
using DS.MSClient.Properties;
using QuickFrame.Common.Configuration;

namespace DS.MSClient.UIControl
{
	/// <summary>
	///     �Զ���GridControl�ؼ�
	///     1�����Ӽ��ء�����grid��ʽ����
	/// </summary>
	[DesignerCategory("")]
	[ToolboxItem(true)]
	public class CGridControl : GridControl
	{
		public CGridControl() : base() { }
		/// <summary>
		///     ��ʾ�Զ�����ʾ�и߰�ť
		/// </summary>
		[Browsable(true)]
		[Description("��ʾgrid���ײ��и��л���ť(�������롢׷�ӡ�ɾ����ȡ��)"), Category("�Զ�������"), DefaultValue("true")]
		public bool ShowCustomRowHeightButton
		{
			get { return _showCustomRowHeightButton; }
			set { _showCustomRowHeightButton = value; }
		}


		/// <summary>
		///     ��ʾ�������ز˵���
		/// </summary>
		[Browsable(true)]
		[Description("��ʾ�������ز˵���"), Category("�Զ�������"), DefaultValue("true")]
		public bool ShowImmediatelyDownLoadMenu
		{
			get { return _showImmediatelyDownLoadMenu; }
			set { _showImmediatelyDownLoadMenu = value; }
		}

		protected override void RegisterAvailableViewsCore(InfoCollection collection)
		{
			base.RegisterAvailableViewsCore(collection);
			collection.Add(new CGridViewInfoRegistrator());
		}

		#region �Զ��尴ť���˵�����������á�����

		private NavigatorCustomButton _btnInsert;
		private NavigatorCustomButton _btnAdd;
		private NavigatorCustomButton _btnDelete;
		private NavigatorCustomButton _btnCancel;
		private NavigatorCustomButton _btnRowHeight;


		private bool _showCustomRowHeightButton = true;
		private bool _showCustomHeaderMenu = true;
		private bool _showImmediatelyDownLoadMenu = true;

		/// <summary>
		///     ��ʾ�Զ���������ͷ���˵�
		/// </summary>
		[Browsable(true)]
		[Description("��ʾ�Զ������ͷ���˵�"), Category("�Զ�������"), DefaultValue("false")]
		public bool ShowCustomHeaderMenu
		{
			get { return _showCustomHeaderMenu; }
			set { _showCustomHeaderMenu = value; }
		}

		/// <summary>
		///     ��ʾ�Զ��嵼������ť
		/// </summary>
		[Browsable(true)]
		[Description("��ʾgrid���ײ��Զ��嵼����ť(�������롢׷�ӡ�ɾ����ȡ��)"), Category("�Զ�������"), DefaultValue("false")]
		public bool ShowCustomNavigationButtons { get; set; }

		/// <summary>
		///     �����Զ���grid���ݵ�����ť�Ƿ����
		/// </summary>
		/// <param name="insertButtonEnabled">���밴ť�Ƿ����</param>
		/// <param name="addButtonEnabled">׷�Ӱ�ť�Ƿ����</param>
		/// <param name="deleteButtonEnabled">ɾ����ť�Ƿ����</param>
		/// <param name="cancelButtonEnabled">ȡ����ť�Ƿ����</param>
		public void SetCustomNavicationButtonEnabled(bool insertButtonEnabled, bool addButtonEnabled, bool deleteButtonEnabled,
			bool cancelButtonEnabled)
		{
			if (_btnInsert != null) _btnInsert.Enabled = insertButtonEnabled;
			if (_btnAdd != null) _btnAdd.Enabled = addButtonEnabled;
			if (_btnDelete != null) _btnDelete.Enabled = deleteButtonEnabled;
			if (_btnCancel != null) _btnCancel.Enabled = cancelButtonEnabled;
		}

		/// <summary>
		///     �����Զ���grid���ݵ��������׷�Ӱ�ť�Ƿ����
		/// </summary>
		/// <param name="enabled"></param>
		public void SetCustomNavicationInsert_AddButtonEnabled(bool enabled)
		{
			if (_btnInsert != null) _btnInsert.Enabled = enabled;
			if (_btnAdd != null) _btnAdd.Enabled = enabled;
		}

		/// <summary>
		///     �����Զ���grid���ݵ���ȡ����ť�Ƿ����
		/// </summary>
		/// <param name="enabled"></param>
		public void SetCustomNavicationCancelButtonEnabled(bool enabled)
		{
			if (_btnCancel != null) _btnCancel.Enabled = enabled;
		}

		/// <summary>
		///     �����Զ���grid���ݵ���ɾ����ť�Ƿ����
		/// </summary>
		/// <param name="enabled"></param>
		public void SetCustomNavicationDeleteButtonEnabled(bool enabled)
		{
			if (_btnDelete != null) _btnDelete.Enabled = enabled;
		}

		#endregion

		#region ���غͱ������grid���

		/// <summary>
		///     �򿪺���������
		/// </summary>
		public bool ImmediatelyDownLoad { get; set; }

		private bool _stylesave; //�Ƿ��Ѿ��������
		private string _strPath = string.Empty; //·��
		private readonly string _stylePath = "Style"; //style·��
		private string _moduleName = string.Empty; //ģ������
		private string _layoutXmlName = string.Empty; //����xml�ļ�����
		private string _rowNumberName = string.Empty; //���ڱ����к�״̬
		private string _immediatelyDownloadName = string.Empty; //���ڱ�����������״̬

		private int _totalRecordCount; //��ǰ���ݼ���¼��,�����ж��Ƿ���������������ݿ��ѯ
		private int _pageSize = 100; //��ǰҳ��ķ�ҳ��¼��

		//----�߼��˵����
		protected PopupMenu PopupMenuMain;
		protected BarManager BarManagerMain;
		private BarButtonItem _pbarbtnColumnConfig;
		private BarButtonItem _pbarbtnAdvanceSearch;
		private BarButtonItem _pbarbtnRowHeight;
		private BarCheckItem _pbarbtnRowNumber; //�к�
		private BarCheckItem _pbarbtnImmediatelyDownload; //�򿪺�������������
		private ItemClickEventHandler _advanceSearchItemClick;

		public delegate void DelegateCustomMethod(); //�Զ��巽��

		public delegate int DelegateCustomGetMethod(); //�Զ��巽��

		public delegate void DelegateCustomCallMethod(string operateType); //�Զ��巽��

		//��������,���Ҫ��ק�Ķ���
		private GridHitInfo _downHitInfo;
		private DXMouseEventArgs _oldargs;

		/// <summary>
		///     �߼���ѯ����
		/// </summary>
		public DelegateCustomMethod AdvanceSearchMethod { get; set; }

		/// <summary>
		///     ��ҳ�ֶ������ѯ����
		/// </summary>
		public DelegateCustomMethod PageSortOrderSearchMethod { get; set; }

		/// <summary>
		///     ��ȡÿҳ��������
		/// </summary>
		public DelegateCustomGetMethod GetPageSizeMethod { get; set; }

		/// <summary>
		///     ��ȡ�ܼ�¼������
		/// </summary>
		public DelegateCustomGetMethod GetTotalRecordCountMethod { get; set; }

		/// <summary>
		///     �����Զ���grid������ť�����롢׷�ӡ�ɾ����ȡ��������¼�,��Ӧ����:insert,add,delete,cancel
		/// </summary>
		public DelegateCustomCallMethod CallCustomNavicationButtonClick { get; set; }

		/// <summary>
		///     ���غͱ������grid���
		///     1�������˵���߼���ѯ�������á��кš��и�
		///     2�������߼���ѯ
		/// </summary>
		/// <param name="barManager">barManager</param>
		/// <param name="moduleName">ģ������</param>
		/// <param name="advanceSearchItemClick">�߼���ѯ��ť�¼�</param>
		public void LoadGridLayout(BarManager barManager, string moduleName, ItemClickEventHandler advanceSearchItemClick)
		{
			RegisterAdvanceSearch(advanceSearchItemClick);
			LoadGridLayout(barManager, moduleName);
		}

		/// <summary>
		///     ���غͱ������grid���
		///     1�������˵���߼���ѯ�������á��кš��и�
		///     2�������߼���ѯ
		///     3��������ҳ�ֶ������ѯ����
		/// </summary>
		/// <param name="barManager">barManager</param>
		/// <param name="moduleName">ģ������</param>
		/// <param name="advanceSearchMethod"></param>
		/// <param name="pageSortOrderSearchMethod">��ҳ�ֶ������ѯί���¼�</param>
		/// <param name="getPageSizeMethod">ÿҳ��¼��ί���¼�</param>
		/// <param name="getTotalRecordCountMethod">�ܼ�¼��ί���¼�</param>
		public void LoadGridLayout(BarManager barManager, string moduleName, DelegateCustomMethod advanceSearchMethod,
			DelegateCustomMethod pageSortOrderSearchMethod, DelegateCustomGetMethod getPageSizeMethod,
			DelegateCustomGetMethod getTotalRecordCountMethod)
		{
			GetPageSizeMethod = getPageSizeMethod;
			GetTotalRecordCountMethod = getTotalRecordCountMethod;
			_pageSize = GetPageSizeMethod();
			RegisterAdvanceSearch(advanceSearchMethod, pageSortOrderSearchMethod);
			LoadGridLayout(barManager, moduleName);
		}

		/// <summary>
		///     ���غͱ������grid���
		///     1�������˵���߼���ѯ�������á��кš��и�
		///     2��������ҳ�ֶ������ѯ����(�������߼���ѯ)
		/// </summary>
		/// <param name="barManager">barManager</param>
		/// <param name="moduleName">ģ������</param>
		/// <param name="pageSortOrderSearchMethod">��ҳ�ֶ������ѯί���¼�</param>
		/// <param name="getPageSizeMethod">ÿҳ��¼��</param>
		/// <param name="getTotalRecordCountMethod">�ܼ�¼��</param>
		public void LoadGridLayout(BarManager barManager, string moduleName, DelegateCustomMethod pageSortOrderSearchMethod,
			DelegateCustomGetMethod getPageSizeMethod, DelegateCustomGetMethod getTotalRecordCountMethod)
		{
			GetPageSizeMethod = getPageSizeMethod;
			GetTotalRecordCountMethod = getTotalRecordCountMethod;
			RegisterAdvanceSearch(null, pageSortOrderSearchMethod);
			LoadGridLayout(barManager, moduleName);
		}

		/// <summary>
		///     ���غͱ������grid���
		///     1�������˵���߼���ѯ�������á��кš��и�
		///     2�������߼���ѯ����
		/// </summary>
		/// <param name="barManager">barManager</param>
		/// <param name="moduleName">ģ������</param>
		/// <param name="advanceSearchMethod">�߼���ѯί���¼�</param>
		public void LoadGridLayout(BarManager barManager, string moduleName, DelegateCustomMethod advanceSearchMethod)
		{
			RegisterAdvanceSearch(advanceSearchMethod, null);
			LoadGridLayout(barManager, moduleName);
		}

		/// <summary>
		///     ���غͱ������grid���
		///     1�������˵�������á��кš��иߣ��޸߼���ѯѡ��
		///     2����������ҳ�ֶ������ѯ
		/// </summary>
		/// <param name="barManager">barManager</param>
		/// <param name="moduleName">ģ������</param>
		public void LoadGridLayout(BarManager barManager, string moduleName)
		{
			try
			{
				_moduleName = moduleName;
				_layoutXmlName = MainView.Name + ".xml"; // layoutXMLName;
				_strPath = AppDomain.CurrentDomain.BaseDirectory + _stylePath + "\\" + Program.CurrentEmployee.EmployeeCode;
				_rowNumberName = Program.CurrentEmployee.EmployeeCode + "_" + moduleName + "_" + _layoutXmlName;
				_immediatelyDownloadName = Program.CurrentEmployee.EmployeeCode + "_" + moduleName + "_" + _layoutXmlName;
				//���ؽ���grid���
				if (LayOutIsAlive(@"\" + moduleName + "\\" + _layoutXmlName)) //�����grid��ʽ�������
				{
					MainView.RestoreLayoutFromXml(_strPath + @"\" + moduleName + "\\" + _layoutXmlName, OptionsLayoutBase.FullLayout);
					//ȡ������gridview��ʽ��Ϣ
				}
				else if (!LayOutIsAlive(@"\" + moduleName + "\\" + "Default_" + _layoutXmlName)) //����Ĭ��gridview��ʽ�����ڻ�ԭ
				{
					try
					{
						if (!Directory.Exists(_strPath + @"\" + _moduleName))
						{
							Directory.CreateDirectory(_strPath + @"\" + _moduleName);
						}
						MainView.SaveLayoutToXml(_strPath + @"\" + _moduleName + "\\Default_" + _layoutXmlName,
							OptionsLayoutBase.FullLayout); //����������Ϣ
					}
					catch
					{
						// ignored
					}
				}

				//ע���뿪���汣��grid����¼����к�״̬
				ControlRemoved += gc_ControlRemoved;
				LoadGridHeaderMenu(barManager);

				if (ShowCustomNavigationButtons || ShowCustomRowHeightButton)
				{
					var imageList1 = new ImageList {ImageSize = new Size(36, 16)};

					imageList1.Images.Add(Resources.grid_insert);
					imageList1.Images.Add(Resources.grid_add);
					imageList1.Images.Add(Resources.grid_delete);
					imageList1.Images.Add(Resources.grid_cancel);
					imageList1.Images.Add(Resources.grid_rowHeight);
					UseEmbeddedNavigator = true;
					EmbeddedNavigator.Buttons.ImageList = imageList1;
					//�����Դ���ť
					EmbeddedNavigator.Buttons.Append.Visible = false; //����
					EmbeddedNavigator.Buttons.CancelEdit.Visible = false; //ȡ���༭
					EmbeddedNavigator.Buttons.EndEdit.Visible = false; //�����༭
					EmbeddedNavigator.Buttons.Prev.Visible = false; //��һ��
					EmbeddedNavigator.Buttons.PrevPage.Visible = false; //��һҳ
					EmbeddedNavigator.Buttons.Next.Visible = false; //��һ��
					EmbeddedNavigator.Buttons.NextPage.Visible = false; //��һҳ
					EmbeddedNavigator.Buttons.First.Visible = false; //��һ��
					EmbeddedNavigator.Buttons.Last.Visible = false; //���һ��
					EmbeddedNavigator.Buttons.Edit.Visible = false; //�༭
					EmbeddedNavigator.Buttons.Remove.Visible = false; //ɾ��
					EmbeddedNavigator.TextLocation = NavigatorButtonsTextLocation.End;
					EmbeddedNavigator.Text = string.Empty;
					EmbeddedNavigator.TextStringFormat = string.Empty;
					EmbeddedNavigator.ButtonClick += gridControl_EmbeddedNavigator_ButtonClick;
				}
				if (ShowCustomNavigationButtons)
				{
					_btnInsert = new NavigatorCustomButton();
					_btnInsert = EmbeddedNavigator.Buttons.CustomButtons.Add();
					_btnInsert.Tag = "insert";
					//btn_insert.Hint = "����";
					_btnInsert.ImageIndex = 0;

					_btnAdd = new NavigatorCustomButton();
					_btnAdd = EmbeddedNavigator.Buttons.CustomButtons.Add();
					_btnAdd.Tag = "add";
					// btn_add.Hint = "׷��";
					_btnAdd.ImageIndex = 1;

					_btnDelete = new NavigatorCustomButton();
					_btnDelete = EmbeddedNavigator.Buttons.CustomButtons.Add();
					_btnDelete.Tag = "delete";
					//btn_delete.Hint = "ɾ��";
					_btnDelete.ImageIndex = 2;

					_btnCancel = new NavigatorCustomButton();
					_btnCancel = EmbeddedNavigator.Buttons.CustomButtons.Add();
					_btnCancel.Tag = "cancel";
					//btn_cancel.Hint = "ȡ��";
					_btnCancel.ImageIndex = 3;
				}
				if (ShowCustomRowHeightButton)
				{
					var btnRowHeight = EmbeddedNavigator.Buttons.CustomButtons.Add();
					btnRowHeight.Tag = "rowHeight";
					// btnRowHeight.Hint = "�и�";
					btnRowHeight.ImageIndex = 4;
				}
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		/// ������ʽ
		/// </summary>
		public void SaveStyle()
		{
			try
			{
				if (!_stylesave)
				{
					if (!Directory.Exists(_strPath + @"\" + _moduleName))
					{
						Directory.CreateDirectory(_strPath + @"\" + _moduleName);
					}
					MainView.SaveLayoutToXml(_strPath + @"\" + _moduleName + "\\" + _layoutXmlName, OptionsLayoutBase.FullLayout);
					//����������Ϣ
					//�����к�״̬ 
					Ini.WriteItem("GridRowNumber", _rowNumberName, _pbarbtnRowNumber.Checked.ToString());
					//�����Ƿ���������״̬
					Ini.WriteItem("ImmediatelyDownload", _immediatelyDownloadName, _pbarbtnImmediatelyDownload.Checked.ToString());
					_stylesave = true;
				}
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     grid��ťclick
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridControl_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
		{
			try
			{
				var button = e.Button as NavigatorCustomButton;
				if (button == null) return;
				var btn = button;
				if (btn.Tag != null)
				{
					if (btn.Tag.ToString() == "rowHeight")
					{
						var gridView = MainView as GridView;
						if (gridView == null) return;
						gridView.RowHeight = gridView.RowHeight == -1 ? 35 : -1;
					}
					else
					{
						if (CallCustomNavicationButtonClick != null)
						{
							CallCustomNavicationButtonClick(btn.Tag.ToString());
						}
					}
				}
				e.Handled = true;
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     �ж϶�Ӧ����ļ��Ƿ����
		/// </summary>
		/// <param name="layOutName"></param>
		private bool LayOutIsAlive(string layOutName)
		{
			var strPath = _strPath;
			if (!Directory.Exists(strPath))
			{
				Directory.CreateDirectory(strPath);
			}
			//�����ļ�������·��
			strPath += @"\" + layOutName;

			if (File.Exists(strPath))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		///     ���������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gc_ControlRemoved(object sender, ControlEventArgs e)
		{
			SaveStyle();
		}

		#endregion

		#region ����gridͷ�����˵�

		/// <summary>
		///     ע��߼���ѯ��ť�¼�
		/// </summary>
		/// <param name="itemClick"></param>
		private void RegisterAdvanceSearch(ItemClickEventHandler itemClick)
		{
			_advanceSearchItemClick = itemClick;
		}

		/// <summary>
		///     ע��߼���ѯ��ť�¼�
		/// </summary>
		/// <param name="advanceSearchMethod"></param>
		/// <param name="pageSortOrderSearchMethod"></param>
		private void RegisterAdvanceSearch(DelegateCustomMethod advanceSearchMethod,
			DelegateCustomMethod pageSortOrderSearchMethod)
		{
			AdvanceSearchMethod = advanceSearchMethod;
			PageSortOrderSearchMethod = pageSortOrderSearchMethod;

			CloseLocalSort();
		}

		private void CloseLocalSort()
		{
			var gv = Views[0] as GridView;
			if (gv == null) return;
			foreach (GridColumn column in gv.Columns)
			{
				if (column.SortMode != ColumnSortMode.Custom) column.SortMode = ColumnSortMode.Custom;
			}
			gv.CustomColumnSort += (s, e) =>
			{
				if (e.Value1 == e.Value2) return;
				e.Handled = true;
				switch (e.SortOrder)
				{
					case ColumnSortOrder.Ascending:
						e.Result = -1;
						break;
					case ColumnSortOrder.Descending:
						e.Result = 1;
						break;
				}
			};
		}

		/// <summary>
		///     ����ͷ�����˵�
		/// </summary>
		private void LoadGridHeaderMenu(BarManager barManager)
		{
			if (!ShowCustomHeaderMenu) return;
			BarManagerMain = barManager;
			var gridView = MainView as GridView;
			if (gridView == null) return;
			gridView.FixedLineWidth = 2;
			//gridView.Appearance.FixedLine.BackColor = Color.PaleVioletRed;


			gridView.CustomDrawRowIndicator += gridView_CustomDrawRowIndicator;
			gridView.Click += gridView_Click; //����gridview
			gridView.DragObjectStart += gridView_DragObjectStart; //��ʼ��קgrid��ͷ,���ڴ�����ק��̬���ɶ�����
			gridView.DragObjectDrop += gridView_DragObjectDrop; //ֹͣ��קgrid��ͷ�����ڴ�����ק��̬���ɶ�����
			gridView.MouseDown += gridView_MouseDown;
			//��ʼ���˵� 
			PopupMenuMain = new PopupMenu();
			_pbarbtnColumnConfig = new BarButtonItem
			{
				Caption = @"����",
				Id = 0,
				Name = "pbarbtn_ColumnConfig"
			};

			_pbarbtnAdvanceSearch = new BarButtonItem
			{
				Caption = @"�߼���ѯ",
				Id = 2,
				Name = "pbarbtn_AdvanceSearch",
				Visibility = _advanceSearchItemClick == null && AdvanceSearchMethod == null
					? BarItemVisibility.Never
					: BarItemVisibility.Always
			};

			_pbarbtnRowNumber = new BarCheckItem
			{
				Caption = @"�к�",
				Id = 3,
				Name = "pbarbtn_RowHeight"
			};


			_pbarbtnRowHeight = new BarButtonItem
			{
				Caption = @"�и�",
				Id = 4,
				Name = "pbarbtn_RowHeight"
			};

			_pbarbtnImmediatelyDownload = new BarCheckItem
			{
				Caption = @"�򿪺���������",
				Id = 5,
				Name = "pbarbtn_ImmediatelyDownload",
				Visibility = ShowImmediatelyDownLoadMenu
					? BarItemVisibility.Always
					: BarItemVisibility.Never
			};

			_pbarbtnColumnConfig.ItemClick += pbarbtn_ItemClick;
			_pbarbtnAdvanceSearch.ItemClick += pbarbtn_ItemClick;
			_pbarbtnRowHeight.ItemClick += pbarbtn_ItemClick;
			_pbarbtnRowNumber.ItemClick += pbarbtn_ItemClick;
			_pbarbtnImmediatelyDownload.ItemClick += pbarbtn_ItemClick;

			PopupMenuMain.LinksPersistInfo.AddRange(new[]
			{
				new LinkPersistInfo(_pbarbtnAdvanceSearch),
				new LinkPersistInfo(_pbarbtnColumnConfig, true),
				new LinkPersistInfo(_pbarbtnRowNumber),
				new LinkPersistInfo(_pbarbtnRowHeight),
				new LinkPersistInfo(_pbarbtnImmediatelyDownload, true)
			});
			PopupMenuMain.Manager = BarManagerMain;
			PopupMenuMain.Name = "popupMenu_Main";
			//�����к�
			var rowNumberChecked = Ini.ReadItem("GridRowNumber", _rowNumberName);
			_pbarbtnRowNumber.Checked = !string.IsNullOrEmpty(rowNumberChecked) && Convert.ToBoolean(rowNumberChecked);
			gridView.IndicatorWidth = _pbarbtnRowNumber.Checked ? 35 : 20; //�к��п�
			//�򿪺��Ƿ���������
			var immediatelyDownload = Ini.ReadItem("ImmediatelyDownload", _immediatelyDownloadName);
			_pbarbtnImmediatelyDownload.Checked = !string.IsNullOrEmpty(immediatelyDownload) && Convert.ToBoolean(immediatelyDownload);
			ImmediatelyDownLoad = _pbarbtnImmediatelyDownload.Checked;
		}

		//��갴���¼�
		private void gridView_MouseDown(object sender, MouseEventArgs e)
		{
			var view = sender as GridView;
			if (view == null) return;
			_downHitInfo = null;
			var hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
			if (ModifierKeys != Keys.None) return;
			if (e.Button == MouseButtons.Left && hitInfo.InColumnPanel)
			{
				_downHitInfo = hitInfo;
				_oldargs = e as DXMouseEventArgs;
			}
		}

		/// <summary>
		///     ����RowIndicator,��Ӳ�ѯ��ť���������ذ�ťͼƬ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
		{
			try
			{
				if (e.Info.IsRowIndicator) //�����RowIndicator��
				{
					if (e.RowHandle >= 0 && _pbarbtnRowNumber.Checked) //�к�
					{
						e.Info.DisplayText = (e.RowHandle + 1).ToString();
					}
					//else if (e.RowHandle == DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)//����ǹ�����
					//{

					//    e.Info.ImageIndex = -1;
					//    e.Painter.DrawObject(e.Info);
					//    Rectangle r = e.Bounds;
					//    r.Inflate(-1, -1);
					//    int x = r.X + (r.Width - 16) / 2;//imageList1.ImageSize.Width=16
					//    int y = r.Y + (r.Height - 16) / 2;
					//    e.Graphics.DrawImageUnscaled(Client.Controls.StaticImageList.Instance.ImageList_global.Images[1], x, y);//�������ذ�ťͼƬ

					//    e.Handled = true;

					//}
				}
				else //����������ߵ�RowIndicator��
				{
					e.Info.ImageIndex = -1;
					e.Painter.DrawObject(e.Info);
					var r = e.Bounds;
					r.Inflate(-1, -1);
					var x = r.X + (r.Width - 16)/2;

					var y = r.Y + (r.Height - 16)/2;
					e.Graphics.DrawImageUnscaled(StaticImageList.Instance.ImageList_global.Images[19], x, y); //RowIndicator��ͷ����ѯ��ťͼƬ
					e.Handled = true;
				}
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     ����gridview�������˵�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView_Click(object sender, EventArgs e)
		{
			try
			{
				var gridView = sender as GridView;
				if (gridView == null) return;
				Cursor.Current = Cursors.WaitCursor;
				var args = e as DXMouseEventArgs;
				if (args == null) return;
				var hitInfo = gridView.CalcHitInfo(args.Location);
				if (hitInfo != null)
				{
					if (!hitInfo.InGroupPanel)
					{
						if (!hitInfo.InColumn) //����Ŵ�ͼ�꣬�����˵�
						{
							if (hitInfo.HitTest.ToString() == "ColumnButton")
							{
								PopupMenuMain.ShowPopup(Cursor.Position);
								//this.popupMenu_Main.ShowPopup(this.barManager_Main, Cursor.Position); //�����˵� 
							}
						}
						else if (hitInfo.InColumn) //��װ����
						{
							if (hitInfo.HitTest.ToString() == "Column" && hitInfo.Column != null)
							{
								if (PageSortOrderSearchMethod == null || GetPageSizeMethod == null || GetTotalRecordCountMethod == null)
									return; //δ�����ҳ�ֶ������ѯ����
								_totalRecordCount = GetTotalRecordCountMethod();
								if (gridView.DataRowCount == 0 || _totalRecordCount == 0) return; //���û�м�¼��������Ҫ����

								_pageSize = GetPageSizeMethod();
								//if (_pageSize >= _totalRecordCount) return; //����ܼ�¼��С��ÿҳ��¼������ֻ��Ҫ���������¼��û�б�Ҫ�����ݿ��ѯ
								if (hitInfo.Column.FieldName == "Choose") return; //ѡ�����ų�      
								var order = hitInfo.Column.SortOrder; //��ס����

								if (_downHitInfo != null)
								{
									if (_downHitInfo.Column.FieldName != hitInfo.Column.FieldName) //����н���������갴��ʱ�������Ϣ������ͷŵ�����Ϣ��ͬ���д���
									{
										return;
									}
									else
									{
										if (_oldargs != null)
										{
											if (args.Location.Y - _oldargs.Location.Y > 0.1) //����н�����С����갴��ʱ�������Ϣ��ͬ���ò�ͬ�����λ�ô���
											{
												return;
											}
											else
											{
												if (args.Location.X != _oldargs.Location.X)
												{
													return;
												}
											}
										}
									}
								}

								//����ȡ��
								if (order == ColumnSortOrder.None)
								{
									order = ColumnSortOrder.Ascending;
								}
								else if (order == ColumnSortOrder.Ascending)
								{
									order = ColumnSortOrder.Descending;
								}
								else if (order == ColumnSortOrder.Descending)
								{
									order = ColumnSortOrder.Ascending;
								}
								foreach (GridColumn col in gridView.Columns)
								{
									col.SortOrder = ColumnSortOrder.None; //��������е����� 
								}
								hitInfo.Column.SortOrder = order; //���õ�ǰ���������
								PageSortOrderSearchMethod(); //���÷�ҳ�ֶ������ѯ                            
							}
						}
					}
				}
			}
			catch
			{
				// ignored
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}


		/// <summary>
		///     �˵�����
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pbarbtn_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (e.Item == _pbarbtnAdvanceSearch) //�߼���ѯ
				{
					if (_advanceSearchItemClick != null)
					{
						_advanceSearchItemClick(sender, e);
					}
					else
					{
						AdvanceSearchMethod();
					}
				}
				else if (e.Item == _pbarbtnColumnConfig) //������
				{
					var gridView = MainView as GridView;
					var form = new FormColumnConfig
					{
						gv_current = gridView,
						defaultLayoutXMLName = _strPath + "\\" + _moduleName + "\\Default_" + _layoutXmlName
					};
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						Application.DoEvents();
					}
				}
				else if (e.Item == _pbarbtnRowNumber) //�к�
				{
					var gridView = MainView as GridView;
					if (gridView == null) return;
					gridView.IndicatorWidth = _pbarbtnRowNumber.Checked ? 35 : 20;
				}
				else if (e.Item == _pbarbtnRowHeight) //�и�
				{
					var gridView = MainView as GridView;
					if (gridView == null) return;
					gridView.RowHeight = gridView.RowHeight == -1 ? 35 : -1;
				}
				else if (e.Item == _pbarbtnImmediatelyDownload) //�򿪺���������
				{
					ImmediatelyDownLoad = _pbarbtnImmediatelyDownload.Checked;
				}
			}
			catch
			{
				// ignored
			}
		}

		#endregion

		#region ��������У���ק��̬���ɶ�����

		//���ڼ�¼������ԭ������ʾλ��
		private readonly SortedList _htIndex = new SortedList(new MySort());

		public CGridControl(NavigatorCustomButton btnRowHeight)
		{
			_btnRowHeight = btnRowHeight;
			ShowCustomNavigationButtons = false;
		}

		/// <summary>
		///     ��ק��ͷʱ�����涳������Ϣ���Ա���ק����л�ԭ�͸���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView_DragObjectStart(object sender, DragObjectStartEventArgs e)
		{
			try
			{
				var gridView = sender as GridView;
				if (gridView == null) return;
				gridView.BeginUpdate();
				lock (_htIndex.SyncRoot) //��¼ԭ���Ķ������
				{
					_htIndex.Clear();
					for (var i = gridView.VisibleColumns.Count - 1; i >= 0; i--)
					{
						if (gridView.VisibleColumns[i].Fixed == FixedStyle.Left)
						{
							_htIndex.Add(gridView.VisibleColumns[i].FieldName, gridView.VisibleColumns[i].VisibleIndex);
							gridView.VisibleColumns[i].Fixed = FixedStyle.None;
						}
					}
				}
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     ��ק��ͷֹͣʱ��������ק����л�ԭ�͸���
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView_DragObjectDrop(object sender, DragObjectDropEventArgs e)
		{
			GridView gridView = null;
			try
			{
				gridView = sender as GridView;
				if (gridView == null) return;
				var currentColumn = e.DragObject as GridColumn;
				var index = e.DropInfo.Index; //-1����ʾû�б仯��-100��ʾ�ѳ��ؼ��⣬��������
				if (index == -1 || index == -100 || _htIndex.Count == 0) //count=0��˵��û�ж����У��Ͳ���Ҫ������
				{
					lock (_htIndex.SyncRoot)
					{
						foreach (DictionaryEntry de in _htIndex)
						{
							foreach (GridColumn col in gridView.VisibleColumns)
							{
								if (de.Key.ToString() == col.FieldName)
								{
									col.Fixed = FixedStyle.Left;
									col.VisibleIndex = Convert.ToInt32(_htIndex[col.FieldName]);
									break;
								}
							}
						}
					}
				}
				else if (e.DropInfo.Index > _htIndex.Count - 1) //���������У�Ŀ�ĵ��ڶ����е��Ҳ෶Χ�������ڶ����У�
				{
					//���������Ҫ�жϲ��ų��Ѷ����б�����ȥ�����
					lock (_htIndex.SyncRoot)
					{
						foreach (DictionaryEntry de in _htIndex)
						{
							foreach (GridColumn col in gridView.VisibleColumns)
							{
								if (de.Key.ToString() == col.FieldName)
								{
									if (currentColumn != null && col.FieldName == currentColumn.FieldName)
									{
										col.Fixed = FixedStyle.None; //�����������е����
										break;
									}
									col.Fixed = FixedStyle.Left;
									col.VisibleIndex = Convert.ToInt32(_htIndex[col.FieldName]);
									break;
								}
							}
						}
					}
				}
				else //��Ҫ���°��Ŷ���˳��
				{
					//�ȶ�������һά���飬�ֱ������洢Key��Value
					var keyArray = new string[_htIndex.Count];
					var valueArray = new int[_htIndex.Count];
					//��HashTable�е�Key��Value�ֱ𸳸�������������  

					_htIndex.Keys.CopyTo(keyArray, 0);
					_htIndex.Values.CopyTo(valueArray, 0);
					Array.Sort(valueArray, keyArray); //��ֵ����

					var listKey = new List<string>(keyArray);
					if (currentColumn != null) listKey.Insert(e.DropInfo.Index, currentColumn.FieldName); //���뵱ǰ����λ�ã�ȡ��ԭ���Ķ�����λ��

					foreach (string t in listKey)
					{
						for (var i = 0; i < gridView.VisibleColumns.Count; i++)
						{
							if (gridView.VisibleColumns[i].Fixed == FixedStyle.Left) continue; //�Ѿ������򲻴���
							if (gridView.VisibleColumns[i].FieldName == t)
							{
								gridView.VisibleColumns[i].Fixed = FixedStyle.Left; //�����µ�˳�����ö����м���  
								break;
							}
						}
					}
				}
			}
			catch
			{
				// ignored
			}
			finally
			{
				if (gridView != null) gridView.EndUpdate();
			}
		}

		#endregion
	}

	/// <summary>
	///     ������
	/// </summary>
	internal class MySort : IComparer
	{
		public int Compare(object x, object y)
		{
			return -1;
		}
	}
}