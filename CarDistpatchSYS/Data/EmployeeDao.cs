﻿using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CarDistpatchSYS;
using QuickFrame.Model;
using QuickFrame.Common.Exception;
using QuickFrame.Common.Converter;
using DS.Common.Exception;


namespace DS.Data
{
    /// <summary>
    /// 模块：数据访问
    /// 作用：数据访问类:EmployeeDao
    /// 作者：zyl
    /// 代码生成日期：2017-03-06
    /// 最后修改人：zyl
    /// 最后修改日期：2017-03-06
    /// 说明：
    /// </summary>
    public class EmployeeDao
    {


        /// <summary>
        /// 简单查询
        /// </summary>
        /// <param name="sql"></param>
        public List<Employee> QueryGetList(string sql)
        {
            try
            {
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<Employee> _list = ModelConvert.ToList<Employee>(dt);
                return _list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="sql"></param>
        public Employee GetModel(int EmployeeID)
        {
            try
            {
                string sql = string.Format("select * from t_employee where int EmployeeID = {0} limit 1", EmployeeID);
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                Employee model = ModelConvert.ToModel<Employee>(dt);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="sql"></param>
        public bool Add(Employee model)
        {
            try
            {
                var parameters = new List<QfParameter>();
                parameters.Add(new QfParameter("EmployeeID", model.EmployeeID));
                parameters.Add(new QfParameter("Degree", string.Format(@"'{0}'", model.Degree)));
                parameters.Add(new QfParameter("Cellphone", string.Format(@"'{0}'", model.Cellphone)));
                parameters.Add(new QfParameter("Email", string.Format(@"'{0}'", model.Email)));
                parameters.Add(new QfParameter("QQ", string.Format(@"'{0}'", model.QQ)));
                parameters.Add(new QfParameter("resume", string.Format(@"'{0}'", model.resume)));
                parameters.Add(new QfParameter("EntryDate", model.EntryDate));
                parameters.Add(new QfParameter("DimissionDate", model.DimissionDate));
                parameters.Add(new QfParameter("Status", model.Status));
                parameters.Add(new QfParameter("Password", string.Format(@"'{0}'", model.Password)));
                parameters.Add(new QfParameter("Note", string.Format(@"'{0}'", model.Note)));
                parameters.Add(new QfParameter("EmployeeCode", string.Format(@"'{0}'", model.EmployeeCode)));
                parameters.Add(new QfParameter("OperateID", model.OperateID));
                parameters.Add(new QfParameter("OperateTime", string.Format(@"'{0}'", model.OperateTime)));
                parameters.Add(new QfParameter("EmployeeName", string.Format(@"'{0}'", model.EmployeeName)));
                parameters.Add(new QfParameter("DepartmentID", model.DepartmentID));
                parameters.Add(new QfParameter("DutyID", model.DutyID));
                parameters.Add(new QfParameter("Sex", model.Sex));
                parameters.Add(new QfParameter("Birthday", model.Birthday));
                parameters.Add(new QfParameter("Address", string.Format(@"'{0}'", model.Address)));
                parameters.Add(new QfParameter("IdentityNo", string.Format(@"'{0}'", model.IdentityNo)));
                string colStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.ParameterName));
                string atColStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.Value));
                string sql = string.Format("insert into t_employee({0}) values ({1})", colStr, atColStr);
                int row = MysqlHelper.ExecuteNonQuery(sql);
                return row == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="sql"></param>
        public bool Delete(Employee model)
        {
            try
            {
                string sql = string.Format("delete * from t_employee where int EmployeeID = {0}", model.EmployeeID);
                int row = MysqlHelper.ExecuteNonQuery(sql);
                return row == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="sql"></param>
        public bool Update(Employee model)
        {
            try
            {
                var parameters = new List<QfParameter>();
                parameters.Add(new QfParameter("EmployeeID", model.EmployeeID));
                parameters.Add(new QfParameter("Degree", string.Format(@"'{0}'", model.Degree)));
                parameters.Add(new QfParameter("Cellphone", string.Format(@"'{0}'", model.Cellphone)));
                parameters.Add(new QfParameter("Email", string.Format(@"'{0}'", model.Email)));
                parameters.Add(new QfParameter("QQ", string.Format(@"'{0}'", model.QQ)));
                parameters.Add(new QfParameter("resume", string.Format(@"'{0}'", model.resume)));
                parameters.Add(new QfParameter("EntryDate", model.EntryDate));
                parameters.Add(new QfParameter("DimissionDate", model.DimissionDate));
                parameters.Add(new QfParameter("Status", model.Status));
                parameters.Add(new QfParameter("Password", string.Format(@"'{0}'", model.Password)));
                parameters.Add(new QfParameter("Note", string.Format(@"'{0}'", model.Note)));
                parameters.Add(new QfParameter("EmployeeCode", string.Format(@"'{0}'", model.EmployeeCode)));
                parameters.Add(new QfParameter("OperateID", model.OperateID));
                parameters.Add(new QfParameter("OperateTime", string.Format(@"'{0}'", model.OperateTime)));
                parameters.Add(new QfParameter("EmployeeName", string.Format(@"'{0}'", model.EmployeeName)));
                parameters.Add(new QfParameter("DepartmentID", model.DepartmentID));
                parameters.Add(new QfParameter("DutyID", model.DutyID));
                parameters.Add(new QfParameter("Sex", model.Sex));
                parameters.Add(new QfParameter("Birthday", model.Birthday));
                parameters.Add(new QfParameter("Address", string.Format(@"'{0}'", model.Address)));
                parameters.Add(new QfParameter("IdentityNo", string.Format(@"'{0}'", model.IdentityNo)));
                string colStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.ParameterName));
                string atColStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.Value));
                string sql = string.Format("update t_employee({0}) values ({1}) where EmployeeID = {2}", colStr, atColStr, model.EmployeeID);
                int row = MysqlHelper.ExecuteNonQuery(sql);
                return row == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="sql"></param>
        public List<Employee> GetList()
        {
            try
            {
                string sql = string.Format(@"select a.*, b.DepartmentName
                                                from t_employee a 
                                                left join t_department b on a.DepartmentID = b.DepartmentID");
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<Employee> _list = ModelConvert.ToList<Employee>(dt);
                return _list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

