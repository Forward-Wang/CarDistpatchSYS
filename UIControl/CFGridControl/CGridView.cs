using System;

namespace DS.MSClient.UIControl
{
    [System.ComponentModel.DesignerCategory("")]
	public class CGridView : DevExpress.XtraGrid.Views.Grid.GridView
    {
        #region �Զ����ֶ�
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDatetime1;//�����Զ����ֶ�,5��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDatetime2;//�����Զ����ֶ�,5��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDatetime3;//�����Զ����ֶ�,5��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDatetime4;//�����Զ����ֶ�,5��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDatetime5;//�����Զ����ֶ�,5��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar1;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar2;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar3;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar4;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar5;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar6;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar7;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar8;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar9;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar10;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar11;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar12;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar13;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar14;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar15;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar16;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar17;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar18;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar19;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar20;//�ı��Զ����ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal1;//��ֵ�Զ����ֶ�,10��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal2;//��ֵ�Զ����ֶ�,10��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal3;//��ֵ�Զ����ֶ�,10��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal4;//��ֵ�Զ����ֶ�,10��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal5;//��ֵ�Զ����ֶ�,10��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal6;//��ֵ�Զ����ֶ�,10��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal7;//��ֵ�Զ����ֶ�,10��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal8;//��ֵ�Զ����ֶ�,10��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal9;//��ֵ�Զ����ֶ�,10��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal10;//��ֵ�Զ����ֶ�,10��

        #endregion
        #region �����ֶ�
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDatetime1;//���������ֶ�,5��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDatetime2;//���������ֶ�,5��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDatetime3;//���������ֶ�,5��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDatetime4;//���������ֶ�,5��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDatetime5;//���������ֶ�,5��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar1;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar2;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar3;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar4;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar5;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar6;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar7;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar8;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar9;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar10;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar11;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar12;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar13;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar14;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar15;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar16;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar17;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar18;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar19;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar20;//�ı������ֶ� ,20��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal1;//��ֵ�����ֶ�,10��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal2;//��ֵ�����ֶ�,10��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal3;//��ֵ�����ֶ�,10��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal4;//��ֵ�����ֶ�,10��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal5;//��ֵ�����ֶ�,10��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal6;//��ֵ�����ֶ�,10��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal7;//��ֵ�����ֶ�,10��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal8;//��ֵ�����ֶ�,10��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal9;//��ֵ�����ֶ�,10��
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal10;//��ֵ�����ֶ�,10��
        #endregion

        public CGridView() : this(null) {}
		public CGridView(DevExpress.XtraGrid.GridControl grid) : base(grid) {
		   
             // ��ʼ���Զ���������
            InitCustomFieldDatetimeColumn();
            // ��ʼ���Զ����ı���
            InitCustomFieldVarcharColumn();
            // ��ʼ���Զ�����ֵ��
            InitCustomFieldDecimalColumn();

            // ��ʼ������������
            InitFlowFieldDatetimeColumn();
            // ��ʼ�������ı���
            InitFlowFieldVarcharColumn();
            // ��ʼ��������ֵ��
            InitFlowFieldDecimalColumn(); 


           //����Զ����е�gridview��
            this.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                //�Զ��������ֶΣ�5��
            this.gridCol_CustomFieldDatetime1,
            this.gridCol_CustomFieldDatetime2,
            this.gridCol_CustomFieldDatetime3,
            this.gridCol_CustomFieldDatetime4,
            this.gridCol_CustomFieldDatetime5,
            //�Զ����ı��ֶΣ�20��
            this.gridCol_CustomFieldVarchar1,
            this.gridCol_CustomFieldVarchar2,
            this.gridCol_CustomFieldVarchar3,
            this.gridCol_CustomFieldVarchar4,
            this.gridCol_CustomFieldVarchar5,
            this.gridCol_CustomFieldVarchar6,
            this.gridCol_CustomFieldVarchar7,
            this.gridCol_CustomFieldVarchar8,
            this.gridCol_CustomFieldVarchar9,
            this.gridCol_CustomFieldVarchar10,
            this.gridCol_CustomFieldVarchar11,
            this.gridCol_CustomFieldVarchar12,
            this.gridCol_CustomFieldVarchar13,
            this.gridCol_CustomFieldVarchar14,
            this.gridCol_CustomFieldVarchar15,
            this.gridCol_CustomFieldVarchar16,
            this.gridCol_CustomFieldVarchar17,
            this.gridCol_CustomFieldVarchar18,
            this.gridCol_CustomFieldVarchar19,
            this.gridCol_CustomFieldVarchar20, 
            //�Զ�����ֵ�ֶ�,10��
            this.gridCol_CustomFieldDecimal1,
            this.gridCol_CustomFieldDecimal2,
            this.gridCol_CustomFieldDecimal3,
            this.gridCol_CustomFieldDecimal4,
            this.gridCol_CustomFieldDecimal5,
            this.gridCol_CustomFieldDecimal6,
            this.gridCol_CustomFieldDecimal7,
            this.gridCol_CustomFieldDecimal8,
            this.gridCol_CustomFieldDecimal9,
            this.gridCol_CustomFieldDecimal10 ,
            //=========�����ֶ�=========
             //���������ֶΣ�5��
            this.gridCol_FlowFieldDatetime1,
            this.gridCol_FlowFieldDatetime2,
            this.gridCol_FlowFieldDatetime3,
            this.gridCol_FlowFieldDatetime4,
            this.gridCol_FlowFieldDatetime5,
            //�����ı��ֶΣ�20��
            this.gridCol_FlowFieldVarchar1,
            this.gridCol_FlowFieldVarchar2,
            this.gridCol_FlowFieldVarchar3,
            this.gridCol_FlowFieldVarchar4,
            this.gridCol_FlowFieldVarchar5,
            this.gridCol_FlowFieldVarchar6,
            this.gridCol_FlowFieldVarchar7,
            this.gridCol_FlowFieldVarchar8,
            this.gridCol_FlowFieldVarchar9,
            this.gridCol_FlowFieldVarchar10,
            this.gridCol_FlowFieldVarchar11,
            this.gridCol_FlowFieldVarchar12,
            this.gridCol_FlowFieldVarchar13,
            this.gridCol_FlowFieldVarchar14,
            this.gridCol_FlowFieldVarchar15,
            this.gridCol_FlowFieldVarchar16,
            this.gridCol_FlowFieldVarchar17,
            this.gridCol_FlowFieldVarchar18,
            this.gridCol_FlowFieldVarchar19,
            this.gridCol_FlowFieldVarchar20, 
            //������ֵ�ֶ�,10��
            this.gridCol_FlowFieldDecimal1,
            this.gridCol_FlowFieldDecimal2,
            this.gridCol_FlowFieldDecimal3,
            this.gridCol_FlowFieldDecimal4,
            this.gridCol_FlowFieldDecimal5,
            this.gridCol_FlowFieldDecimal6,
            this.gridCol_FlowFieldDecimal7,
            this.gridCol_FlowFieldDecimal8,
            this.gridCol_FlowFieldDecimal9,
            this.gridCol_FlowFieldDecimal10  

          
            }); 
		}
        protected override string ViewName { get { return "CGridView"; } }


        public override int FixedLineWidth
        {
            get
            {
                int result = base.FixedLineWidth;
                if (IsColumnPainting)
                    result -= 1;
                return result;
            }
            set
            {
                base.FixedLineWidth = value;
            }
        }

        private bool _IsColumnPainting;
        public bool IsColumnPainting
        {
            get { return _IsColumnPainting; }
            set { _IsColumnPainting = value; }
        }

        #region �Զ�����
        /// <summary>
        /// ��ʼ���Զ���������
        /// </summary>
        private void InitCustomFieldDatetimeColumn()
        {
            // ��ʼ�������Զ����ֶΣ�5��
            this.gridCol_CustomFieldDatetime1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDatetime2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDatetime3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDatetime4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDatetime5 = new DevExpress.XtraGrid.Columns.GridColumn();

            this.gridCol_CustomFieldDatetime1.Name = "gridCol_CustomFieldDatetime1";
            this.gridCol_CustomFieldDatetime1.FieldName = "SelfDatetime1";
            this.gridCol_CustomFieldDatetime1.Caption = "�Զ�������1";
            this.gridCol_CustomFieldDatetime1.Visible = false;
            this.gridCol_CustomFieldDatetime1.Tag = "Choose";

            this.gridCol_CustomFieldDatetime2.Name = "gridCol_CustomFieldDatetime2";
            this.gridCol_CustomFieldDatetime2.FieldName = "SelfDatetime2";
            this.gridCol_CustomFieldDatetime2.Caption = "�Զ�������2";
            this.gridCol_CustomFieldDatetime2.Visible = false;
            this.gridCol_CustomFieldDatetime2.Tag = "Choose";

            this.gridCol_CustomFieldDatetime3.Name = "gridCol_CustomFieldDatetime3";
            this.gridCol_CustomFieldDatetime3.FieldName = "SelfDatetime3";
            this.gridCol_CustomFieldDatetime3.Caption = "�Զ�������3";
            this.gridCol_CustomFieldDatetime3.Visible = false;
            this.gridCol_CustomFieldDatetime3.Tag = "Choose";

            this.gridCol_CustomFieldDatetime4.Name = "gridCol_CustomFieldDatetime4";
            this.gridCol_CustomFieldDatetime4.FieldName = "SelfDatetime4";
            this.gridCol_CustomFieldDatetime4.Caption = "�Զ�������4";
            this.gridCol_CustomFieldDatetime4.Visible = false;
            this.gridCol_CustomFieldDatetime4.Tag = "Choose";

            this.gridCol_CustomFieldDatetime5.Name = "gridCol_CustomFieldDatetime5";
            this.gridCol_CustomFieldDatetime5.FieldName = "SelfDatetime5";
            this.gridCol_CustomFieldDatetime5.Caption = "�Զ�������5";
            this.gridCol_CustomFieldDatetime5.Visible = false;
            this.gridCol_CustomFieldDatetime5.Tag = "Choose";
        }
        /// <summary>
        /// ��ʼ���Զ����ı���
        /// </summary>
        private void InitCustomFieldVarcharColumn()
        { //��ʼ���ı��Զ����ֶΣ�20��
            this.gridCol_CustomFieldVarchar1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar20 = new DevExpress.XtraGrid.Columns.GridColumn();

            this.gridCol_CustomFieldVarchar1.Name = "gridCol_CustomFieldVarchar1";
            this.gridCol_CustomFieldVarchar1.FieldName = "SelfVarchar1";
            this.gridCol_CustomFieldVarchar1.Caption = "�Զ����ı�1";
            this.gridCol_CustomFieldVarchar1.Visible = false;
            this.gridCol_CustomFieldVarchar1.Tag = "Choose";

            this.gridCol_CustomFieldVarchar2.Name = "gridCol_CustomFieldVarchar2";
            this.gridCol_CustomFieldVarchar2.FieldName = "SelfVarchar2";
            this.gridCol_CustomFieldVarchar2.Caption = "�Զ����ı�2";
            this.gridCol_CustomFieldVarchar2.Visible = false;
            this.gridCol_CustomFieldVarchar2.Tag = "Choose";

            this.gridCol_CustomFieldVarchar3.Name = "gridCol_CustomFieldVarchar3";
            this.gridCol_CustomFieldVarchar3.FieldName = "SelfVarchar3";
            this.gridCol_CustomFieldVarchar3.Caption = "�Զ����ı�3";
            this.gridCol_CustomFieldVarchar3.Visible = false;
            this.gridCol_CustomFieldVarchar3.Tag = "Choose";

            this.gridCol_CustomFieldVarchar4.Name = "gridCol_CustomFieldVarchar4";
            this.gridCol_CustomFieldVarchar4.FieldName = "SelfVarchar4";
            this.gridCol_CustomFieldVarchar4.Caption = "�Զ����ı�4";
            this.gridCol_CustomFieldVarchar4.Visible = false;
            this.gridCol_CustomFieldVarchar4.Tag = "Choose";

            this.gridCol_CustomFieldVarchar5.Name = "gridCol_CustomFieldVarchar5";
            this.gridCol_CustomFieldVarchar5.FieldName = "SelfVarchar5";
            this.gridCol_CustomFieldVarchar5.Caption = "�Զ����ı�5";
            this.gridCol_CustomFieldVarchar5.Visible = false;
            this.gridCol_CustomFieldVarchar5.Tag = "Choose";

            this.gridCol_CustomFieldVarchar6.Name = "gridCol_CustomFieldVarchar6";
            this.gridCol_CustomFieldVarchar6.FieldName = "SelfVarchar6";
            this.gridCol_CustomFieldVarchar6.Caption = "�Զ����ı�6";
            this.gridCol_CustomFieldVarchar6.Visible = false;
            this.gridCol_CustomFieldVarchar6.Tag = "Choose";


            this.gridCol_CustomFieldVarchar7.Name = "gridCol_CustomFieldVarchar7";
            this.gridCol_CustomFieldVarchar7.FieldName = "SelfVarchar7";
            this.gridCol_CustomFieldVarchar7.Caption = "�Զ����ı�7";
            this.gridCol_CustomFieldVarchar7.Visible = false;
            this.gridCol_CustomFieldVarchar7.Tag = "Choose";

            this.gridCol_CustomFieldVarchar8.Name = "gridCol_CustomFieldVarchar8";
            this.gridCol_CustomFieldVarchar8.FieldName = "SelfVarchar8";
            this.gridCol_CustomFieldVarchar8.Caption = "�Զ����ı�8";
            this.gridCol_CustomFieldVarchar8.Visible = false;
            this.gridCol_CustomFieldVarchar8.Tag = "Choose";

            this.gridCol_CustomFieldVarchar9.Name = "gridCol_CustomFieldVarchar9";
            this.gridCol_CustomFieldVarchar9.FieldName = "SelfVarchar9";
            this.gridCol_CustomFieldVarchar9.Caption = "�Զ����ı�9";
            this.gridCol_CustomFieldVarchar9.Visible = false;
            this.gridCol_CustomFieldVarchar9.Tag = "Choose";

            this.gridCol_CustomFieldVarchar10.Name = "gridCol_CustomFieldVarchar10";
            this.gridCol_CustomFieldVarchar10.FieldName = "SelfVarchar10";
            this.gridCol_CustomFieldVarchar10.Caption = "�Զ����ı�10";
            this.gridCol_CustomFieldVarchar10.Visible = false;
            this.gridCol_CustomFieldVarchar10.Tag = "Choose";

            this.gridCol_CustomFieldVarchar11.Name = "gridCol_CustomFieldVarchar11";
            this.gridCol_CustomFieldVarchar11.FieldName = "SelfVarchar11";
            this.gridCol_CustomFieldVarchar11.Caption = "�Զ����ı�11";
            this.gridCol_CustomFieldVarchar11.Visible = false;
            this.gridCol_CustomFieldVarchar11.Tag = "Choose";

            this.gridCol_CustomFieldVarchar12.Name = "gridCol_CustomFieldVarchar12";
            this.gridCol_CustomFieldVarchar12.FieldName = "SelfVarchar12";
            this.gridCol_CustomFieldVarchar12.Caption = "�Զ����ı�12";
            this.gridCol_CustomFieldVarchar12.Visible = false;
            this.gridCol_CustomFieldVarchar12.Tag = "Choose";

            this.gridCol_CustomFieldVarchar13.Name = "gridCol_CustomFieldVarchar13";
            this.gridCol_CustomFieldVarchar13.FieldName = "SelfVarchar13";
            this.gridCol_CustomFieldVarchar13.Caption = "�Զ����ı�13";
            this.gridCol_CustomFieldVarchar13.Visible = false;
            this.gridCol_CustomFieldVarchar13.Tag = "Choose";

            this.gridCol_CustomFieldVarchar14.Name = "gridCol_CustomFieldVarchar14";
            this.gridCol_CustomFieldVarchar14.FieldName = "SelfVarchar14";
            this.gridCol_CustomFieldVarchar14.Caption = "�Զ����ı�14";
            this.gridCol_CustomFieldVarchar14.Visible = false;
            this.gridCol_CustomFieldVarchar14.Tag = "Choose";

            this.gridCol_CustomFieldVarchar15.Name = "gridCol_CustomFieldVarchar15";
            this.gridCol_CustomFieldVarchar15.FieldName = "SelfVarchar15";
            this.gridCol_CustomFieldVarchar15.Caption = "�Զ����ı�15";
            this.gridCol_CustomFieldVarchar15.Visible = false;
            this.gridCol_CustomFieldVarchar15.Tag = "Choose";

            this.gridCol_CustomFieldVarchar16.Name = "gridCol_CustomFieldVarchar16";
            this.gridCol_CustomFieldVarchar16.FieldName = "SelfVarchar16";
            this.gridCol_CustomFieldVarchar16.Caption = "�Զ����ı�16";
            this.gridCol_CustomFieldVarchar16.Visible = false;
            this.gridCol_CustomFieldVarchar16.Tag = "Choose";

            this.gridCol_CustomFieldVarchar17.Name = "gridCol_CustomFieldVarchar17";
            this.gridCol_CustomFieldVarchar17.FieldName = "SelfVarchar17";
            this.gridCol_CustomFieldVarchar17.Caption = "�Զ����ı�17";
            this.gridCol_CustomFieldVarchar17.Visible = false;
            this.gridCol_CustomFieldVarchar17.Tag = "Choose";

            this.gridCol_CustomFieldVarchar18.Name = "gridCol_CustomFieldVarchar18";
            this.gridCol_CustomFieldVarchar18.FieldName = "SelfVarchar18";
            this.gridCol_CustomFieldVarchar18.Caption = "�Զ����ı�18";
            this.gridCol_CustomFieldVarchar18.Visible = false;
            this.gridCol_CustomFieldVarchar18.Tag = "Choose";

            this.gridCol_CustomFieldVarchar19.Name = "gridCol_CustomFieldVarchar19";
            this.gridCol_CustomFieldVarchar19.FieldName = "SelfVarchar19";
            this.gridCol_CustomFieldVarchar19.Caption = "�Զ����ı�19";
            this.gridCol_CustomFieldVarchar19.Visible = false;
            this.gridCol_CustomFieldVarchar19.Tag = "Choose";

            this.gridCol_CustomFieldVarchar20.Name = "gridCol_CustomFieldVarchar20";
            this.gridCol_CustomFieldVarchar20.FieldName = "SelfVarchar20";
            this.gridCol_CustomFieldVarchar20.Caption = "�Զ����ı�20";
            this.gridCol_CustomFieldVarchar20.Visible = false;
            this.gridCol_CustomFieldVarchar20.Tag = "Choose";
             
        }
        /// <summary>
        /// ��ʼ���Զ�����ֵ��
        /// </summary>
        private void InitCustomFieldDecimalColumn()
        { //��ʼ����ֵ�Զ����ֶΣ�10��
            this.gridCol_CustomFieldDecimal1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDecimal2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDecimal3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDecimal4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDecimal5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDecimal6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDecimal7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDecimal8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDecimal9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDecimal10 = new DevExpress.XtraGrid.Columns.GridColumn();

            this.gridCol_CustomFieldDecimal1.Name = "gridCol_CustomFieldDecimal1";
            this.gridCol_CustomFieldDecimal1.FieldName = "SelfDecimal1";
            this.gridCol_CustomFieldDecimal1.Caption = "�Զ�����ֵ1";
            this.gridCol_CustomFieldDecimal1.Visible = false;
            this.gridCol_CustomFieldDecimal1.Tag = "Choose";

            this.gridCol_CustomFieldDecimal2.Name = "gridCol_CustomFieldDecimal2";
            this.gridCol_CustomFieldDecimal2.FieldName = "SelfDecimal2";
            this.gridCol_CustomFieldDecimal2.Caption = "�Զ�����ֵ2";
            this.gridCol_CustomFieldDecimal2.Visible = false;
            this.gridCol_CustomFieldDecimal2.Tag = "Choose";

            this.gridCol_CustomFieldDecimal3.Name = "gridCol_CustomFieldDecimal3";
            this.gridCol_CustomFieldDecimal3.FieldName = "SelfDecimal3";
            this.gridCol_CustomFieldDecimal3.Caption = "�Զ�����ֵ3";
            this.gridCol_CustomFieldDecimal3.Visible = false;
            this.gridCol_CustomFieldDecimal3.Tag = "Choose";

            this.gridCol_CustomFieldDecimal4.Name = "gridCol_CustomFieldDecimal4";
            this.gridCol_CustomFieldDecimal4.FieldName = "SelfDecimal4";
            this.gridCol_CustomFieldDecimal4.Caption = "�Զ�����ֵ4";
            this.gridCol_CustomFieldDecimal4.Visible = false;
            this.gridCol_CustomFieldDecimal4.Tag = "Choose";

            this.gridCol_CustomFieldDecimal5.Name = "gridCol_CustomFieldDecimal5";
            this.gridCol_CustomFieldDecimal5.FieldName = "SelfDecimal5";
            this.gridCol_CustomFieldDecimal5.Caption = "�Զ�����ֵ5";
            this.gridCol_CustomFieldDecimal5.Visible = false;
            this.gridCol_CustomFieldDecimal5.Tag = "Choose";

            this.gridCol_CustomFieldDecimal6.Name = "gridCol_CustomFieldDecimal6";
            this.gridCol_CustomFieldDecimal6.FieldName = "SelfDecimal6";
            this.gridCol_CustomFieldDecimal6.Caption = "�Զ�����ֵ6";
            this.gridCol_CustomFieldDecimal6.Visible = false;
            this.gridCol_CustomFieldDecimal6.Tag = "Choose";

            this.gridCol_CustomFieldDecimal7.Name = "gridCol_CustomFieldDecimal7";
            this.gridCol_CustomFieldDecimal7.FieldName = "SelfDecimal7";
            this.gridCol_CustomFieldDecimal7.Caption = "�Զ�����ֵ7";
            this.gridCol_CustomFieldDecimal7.Visible = false;
            this.gridCol_CustomFieldDecimal7.Tag = "Choose";

            this.gridCol_CustomFieldDecimal8.Name = "gridCol_CustomFieldDecimal8";
            this.gridCol_CustomFieldDecimal8.FieldName = "SelfDecimal8";
            this.gridCol_CustomFieldDecimal8.Caption = "�Զ�����ֵ8";
            this.gridCol_CustomFieldDecimal8.Visible = false;
            this.gridCol_CustomFieldDecimal8.Tag = "Choose";

            this.gridCol_CustomFieldDecimal9.Name = "gridCol_CustomFieldDecimal9";
            this.gridCol_CustomFieldDecimal9.FieldName = "SelfDecimal9";
            this.gridCol_CustomFieldDecimal9.Caption = "�Զ�����ֵ9";
            this.gridCol_CustomFieldDecimal9.Visible = false;
            this.gridCol_CustomFieldDecimal9.Tag = "Choose";

            this.gridCol_CustomFieldDecimal10.Name = "gridCol_CustomFieldDecimal10";
            this.gridCol_CustomFieldDecimal10.FieldName = "SelfDecimal10";
            this.gridCol_CustomFieldDecimal10.Caption = "�Զ�����ֵ10";
            this.gridCol_CustomFieldDecimal10.Visible = false;
            this.gridCol_CustomFieldDecimal10.Tag = "Choose";
             
        }
        #endregion


        #region ������
        /// <summary>
        /// ��ʼ���Զ���������
        /// </summary>
        private void InitFlowFieldDatetimeColumn()
        {
            // ��ʼ�������Զ����ֶΣ�5��
            this.gridCol_FlowFieldDatetime1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDatetime2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDatetime3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDatetime4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDatetime5 = new DevExpress.XtraGrid.Columns.GridColumn();

            this.gridCol_FlowFieldDatetime1.Name = "gridCol_FlowFieldDatetime1";
            this.gridCol_FlowFieldDatetime1.FieldName = "FlowDatetime1";
            this.gridCol_FlowFieldDatetime1.Caption = "��������1";
            this.gridCol_FlowFieldDatetime1.Visible = false;
            this.gridCol_FlowFieldDatetime1.Tag = "Choose";

            this.gridCol_FlowFieldDatetime2.Name = "gridCol_FlowFieldDatetime2";
            this.gridCol_FlowFieldDatetime2.FieldName = "FlowDatetime2";
            this.gridCol_FlowFieldDatetime2.Caption = "��������2";
            this.gridCol_FlowFieldDatetime2.Visible = false;
            this.gridCol_FlowFieldDatetime2.Tag = "Choose";

            this.gridCol_FlowFieldDatetime3.Name = "gridCol_FlowFieldDatetime3";
            this.gridCol_FlowFieldDatetime3.FieldName = "FlowDatetime3";
            this.gridCol_FlowFieldDatetime3.Caption = "��������3";
            this.gridCol_FlowFieldDatetime3.Visible = false;
            this.gridCol_FlowFieldDatetime3.Tag = "Choose";

            this.gridCol_FlowFieldDatetime4.Name = "gridCol_FlowFieldDatetime4";
            this.gridCol_FlowFieldDatetime4.FieldName = "FlowDatetime4";
            this.gridCol_FlowFieldDatetime4.Caption = "��������4";
            this.gridCol_FlowFieldDatetime4.Visible = false;
            this.gridCol_FlowFieldDatetime4.Tag = "Choose";

            this.gridCol_FlowFieldDatetime5.Name = "gridCol_FlowFieldDatetime5";
            this.gridCol_FlowFieldDatetime5.FieldName = "FlowDatetime5";
            this.gridCol_FlowFieldDatetime5.Caption = "��������5";
            this.gridCol_FlowFieldDatetime5.Visible = false;
            this.gridCol_FlowFieldDatetime5.Tag = "Choose";
        }
        /// <summary>
        /// ��ʼ���Զ����ı���
        /// </summary>
        private void InitFlowFieldVarcharColumn()
        { //��ʼ���ı��Զ����ֶΣ�20��
            this.gridCol_FlowFieldVarchar1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar20 = new DevExpress.XtraGrid.Columns.GridColumn();

            this.gridCol_FlowFieldVarchar1.Name = "gridCol_FlowFieldVarchar1";
            this.gridCol_FlowFieldVarchar1.FieldName = "FlowVarchar1";
            this.gridCol_FlowFieldVarchar1.Caption = "�����ı�1";
            this.gridCol_FlowFieldVarchar1.Visible = false;
            this.gridCol_FlowFieldVarchar1.Tag = "Choose";

            this.gridCol_FlowFieldVarchar2.Name = "gridCol_FlowFieldVarchar2";
            this.gridCol_FlowFieldVarchar2.FieldName = "FlowVarchar2";
            this.gridCol_FlowFieldVarchar2.Caption = "�����ı�2";
            this.gridCol_FlowFieldVarchar2.Visible = false;
            this.gridCol_FlowFieldVarchar2.Tag = "Choose";

            this.gridCol_FlowFieldVarchar3.Name = "gridCol_FlowFieldVarchar3";
            this.gridCol_FlowFieldVarchar3.FieldName = "FlowVarchar3";
            this.gridCol_FlowFieldVarchar3.Caption = "�����ı�3";
            this.gridCol_FlowFieldVarchar3.Visible = false;
            this.gridCol_FlowFieldVarchar3.Tag = "Choose";

            this.gridCol_FlowFieldVarchar4.Name = "gridCol_FlowFieldVarchar4";
            this.gridCol_FlowFieldVarchar4.FieldName = "FlowVarchar4";
            this.gridCol_FlowFieldVarchar4.Caption = "�����ı�4";
            this.gridCol_FlowFieldVarchar4.Visible = false;
            this.gridCol_FlowFieldVarchar4.Tag = "Choose";

            this.gridCol_FlowFieldVarchar5.Name = "gridCol_FlowFieldVarchar5";
            this.gridCol_FlowFieldVarchar5.FieldName = "FlowVarchar5";
            this.gridCol_FlowFieldVarchar5.Caption = "�����ı�5";
            this.gridCol_FlowFieldVarchar5.Visible = false;
            this.gridCol_FlowFieldVarchar5.Tag = "Choose";

            this.gridCol_FlowFieldVarchar6.Name = "gridCol_FlowFieldVarchar6";
            this.gridCol_FlowFieldVarchar6.FieldName = "FlowVarchar6";
            this.gridCol_FlowFieldVarchar6.Caption = "�����ı�6";
            this.gridCol_FlowFieldVarchar6.Visible = false;
            this.gridCol_FlowFieldVarchar6.Tag = "Choose";

            this.gridCol_FlowFieldVarchar7.Name = "gridCol_FlowFieldVarchar7";
            this.gridCol_FlowFieldVarchar7.FieldName = "FlowVarchar7";
            this.gridCol_FlowFieldVarchar7.Caption = "�����ı�7";
            this.gridCol_FlowFieldVarchar7.Visible = false;
            this.gridCol_FlowFieldVarchar7.Tag = "Choose";

            this.gridCol_FlowFieldVarchar8.Name = "gridCol_FlowFieldVarchar8";
            this.gridCol_FlowFieldVarchar8.FieldName = "FlowVarchar8";
            this.gridCol_FlowFieldVarchar8.Caption = "�����ı�8";
            this.gridCol_FlowFieldVarchar8.Visible = false;
            this.gridCol_FlowFieldVarchar8.Tag = "Choose";

            this.gridCol_FlowFieldVarchar9.Name = "gridCol_FlowFieldVarchar9";
            this.gridCol_FlowFieldVarchar9.FieldName = "FlowVarchar9";
            this.gridCol_FlowFieldVarchar9.Caption = "�����ı�9";
            this.gridCol_FlowFieldVarchar9.Visible = false;
            this.gridCol_FlowFieldVarchar9.Tag = "Choose";

            this.gridCol_FlowFieldVarchar10.Name = "gridCol_FlowFieldVarchar10";
            this.gridCol_FlowFieldVarchar10.FieldName = "FlowVarchar10";
            this.gridCol_FlowFieldVarchar10.Caption = "�����ı�10";
            this.gridCol_FlowFieldVarchar10.Visible = false;
            this.gridCol_FlowFieldVarchar10.Tag = "Choose";

            this.gridCol_FlowFieldVarchar11.Name = "gridCol_FlowFieldVarchar11";
            this.gridCol_FlowFieldVarchar11.FieldName = "FlowVarchar11";
            this.gridCol_FlowFieldVarchar11.Caption = "�����ı�11";
            this.gridCol_FlowFieldVarchar11.Visible = false;
            this.gridCol_FlowFieldVarchar11.Tag = "Choose";

            this.gridCol_FlowFieldVarchar12.Name = "gridCol_FlowFieldVarchar12";
            this.gridCol_FlowFieldVarchar12.FieldName = "FlowVarchar12";
            this.gridCol_FlowFieldVarchar12.Caption = "�����ı�12";
            this.gridCol_FlowFieldVarchar12.Visible = false;
            this.gridCol_FlowFieldVarchar12.Tag = "Choose";

            this.gridCol_FlowFieldVarchar13.Name = "gridCol_FlowFieldVarchar13";
            this.gridCol_FlowFieldVarchar13.FieldName = "FlowVarchar13";
            this.gridCol_FlowFieldVarchar13.Caption = "�����ı�13";
            this.gridCol_FlowFieldVarchar13.Visible = false;
            this.gridCol_FlowFieldVarchar13.Tag = "Choose";

            this.gridCol_FlowFieldVarchar14.Name = "gridCol_FlowFieldVarchar14";
            this.gridCol_FlowFieldVarchar14.FieldName = "FlowVarchar14";
            this.gridCol_FlowFieldVarchar14.Caption = "�����ı�14";
            this.gridCol_FlowFieldVarchar14.Visible = false;
            this.gridCol_FlowFieldVarchar14.Tag = "Choose";

            this.gridCol_FlowFieldVarchar15.Name = "gridCol_FlowFieldVarchar15";
            this.gridCol_FlowFieldVarchar15.FieldName = "FlowVarchar15";
            this.gridCol_FlowFieldVarchar15.Caption = "�����ı�15";
            this.gridCol_FlowFieldVarchar15.Visible = false;
            this.gridCol_FlowFieldVarchar15.Tag = "Choose";

            this.gridCol_FlowFieldVarchar16.Name = "gridCol_FlowFieldVarchar16";
            this.gridCol_FlowFieldVarchar16.FieldName = "FlowVarchar16";
            this.gridCol_FlowFieldVarchar16.Caption = "�����ı�16";
            this.gridCol_FlowFieldVarchar16.Visible = false;
            this.gridCol_FlowFieldVarchar16.Tag = "Choose";

            this.gridCol_FlowFieldVarchar17.Name = "gridCol_FlowFieldVarchar17";
            this.gridCol_FlowFieldVarchar17.FieldName = "FlowVarchar17";
            this.gridCol_FlowFieldVarchar17.Caption = "�����ı�17";
            this.gridCol_FlowFieldVarchar17.Visible = false;
            this.gridCol_FlowFieldVarchar17.Tag = "Choose";

            this.gridCol_FlowFieldVarchar18.Name = "gridCol_FlowFieldVarchar18";
            this.gridCol_FlowFieldVarchar18.FieldName = "FlowVarchar18";
            this.gridCol_FlowFieldVarchar18.Caption = "�����ı�18";
            this.gridCol_FlowFieldVarchar18.Visible = false;
            this.gridCol_FlowFieldVarchar18.Tag = "Choose";

            this.gridCol_FlowFieldVarchar19.Name = "gridCol_FlowFieldVarchar19";
            this.gridCol_FlowFieldVarchar19.FieldName = "FlowVarchar19";
            this.gridCol_FlowFieldVarchar19.Caption = "�����ı�19";
            this.gridCol_FlowFieldVarchar19.Visible = false;
            this.gridCol_FlowFieldVarchar19.Tag = "Choose";

            this.gridCol_FlowFieldVarchar20.Name = "gridCol_FlowFieldVarchar20";
            this.gridCol_FlowFieldVarchar20.FieldName = "FlowVarchar20";
            this.gridCol_FlowFieldVarchar20.Caption = "�����ı�20";
            this.gridCol_FlowFieldVarchar20.Visible = false;
            this.gridCol_FlowFieldVarchar20.Tag = "Choose";

        }
        /// <summary>
        /// ��ʼ���Զ�����ֵ��
        /// </summary>
        private void InitFlowFieldDecimalColumn()
        { //��ʼ����ֵ�Զ����ֶΣ�10��
            this.gridCol_FlowFieldDecimal1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDecimal2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDecimal3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDecimal4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDecimal5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDecimal6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDecimal7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDecimal8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDecimal9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDecimal10 = new DevExpress.XtraGrid.Columns.GridColumn();

            this.gridCol_FlowFieldDecimal1.Name = "gridCol_FlowFieldDecimal1";
            this.gridCol_FlowFieldDecimal1.FieldName = "FlowDecimal1";
            this.gridCol_FlowFieldDecimal1.Caption = "������ֵ1";
            this.gridCol_FlowFieldDecimal1.Visible = false;
            this.gridCol_FlowFieldDecimal1.Tag = "Choose";

            this.gridCol_FlowFieldDecimal2.Name = "gridCol_FlowFieldDecimal2";
            this.gridCol_FlowFieldDecimal2.FieldName = "FlowDecimal2";
            this.gridCol_FlowFieldDecimal2.Caption = "������ֵ2";
            this.gridCol_FlowFieldDecimal2.Visible = false;
            this.gridCol_FlowFieldDecimal2.Tag = "Choose";

            this.gridCol_FlowFieldDecimal3.Name = "gridCol_FlowFieldDecimal3";
            this.gridCol_FlowFieldDecimal3.FieldName = "FlowDecimal3";
            this.gridCol_FlowFieldDecimal3.Caption = "������ֵ3";
            this.gridCol_FlowFieldDecimal3.Visible = false;
            this.gridCol_FlowFieldDecimal3.Tag = "Choose";

            this.gridCol_FlowFieldDecimal4.Name = "gridCol_FlowFieldDecimal4";
            this.gridCol_FlowFieldDecimal4.FieldName = "FlowDecimal4";
            this.gridCol_FlowFieldDecimal4.Caption = "������ֵ4";
            this.gridCol_FlowFieldDecimal4.Visible = false;
            this.gridCol_FlowFieldDecimal4.Tag = "Choose";

            this.gridCol_FlowFieldDecimal5.Name = "gridCol_FlowFieldDecimal5";
            this.gridCol_FlowFieldDecimal5.FieldName = "FlowDecimal5";
            this.gridCol_FlowFieldDecimal5.Caption = "������ֵ5";
            this.gridCol_FlowFieldDecimal5.Visible = false;
            this.gridCol_FlowFieldDecimal5.Tag = "Choose";

            this.gridCol_FlowFieldDecimal6.Name = "gridCol_FlowFieldDecimal6";
            this.gridCol_FlowFieldDecimal6.FieldName = "FlowDecimal6";
            this.gridCol_FlowFieldDecimal6.Caption = "������ֵ6";
            this.gridCol_FlowFieldDecimal6.Visible = false;
            this.gridCol_FlowFieldDecimal6.Tag = "Choose";

            this.gridCol_FlowFieldDecimal7.Name = "gridCol_FlowFieldDecimal7";
            this.gridCol_FlowFieldDecimal7.FieldName = "FlowDecimal7";
            this.gridCol_FlowFieldDecimal7.Caption = "������ֵ7";
            this.gridCol_FlowFieldDecimal7.Visible = false;
            this.gridCol_FlowFieldDecimal7.Tag = "Choose";

            this.gridCol_FlowFieldDecimal8.Name = "gridCol_FlowFieldDecimal8";
            this.gridCol_FlowFieldDecimal8.FieldName = "FlowDecimal8";
            this.gridCol_FlowFieldDecimal8.Caption = "������ֵ8";
            this.gridCol_FlowFieldDecimal8.Visible = false;
            this.gridCol_FlowFieldDecimal8.Tag = "Choose";

            this.gridCol_FlowFieldDecimal9.Name = "gridCol_FlowFieldDecimal9";
            this.gridCol_FlowFieldDecimal9.FieldName = "FlowDecimal9";
            this.gridCol_FlowFieldDecimal9.Caption = "������ֵ9";
            this.gridCol_FlowFieldDecimal9.Visible = false;
            this.gridCol_FlowFieldDecimal9.Tag = "Choose";

            this.gridCol_FlowFieldDecimal10.Name = "gridCol_FlowFieldDecimal10";
            this.gridCol_FlowFieldDecimal10.FieldName = "FlowDecimal10";
            this.gridCol_FlowFieldDecimal10.Caption = "������ֵ10";
            this.gridCol_FlowFieldDecimal10.Visible = false;
            this.gridCol_FlowFieldDecimal10.Tag = "Choose";

        }
        #endregion


    }
}
