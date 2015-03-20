﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDao;
using System.Data;

namespace Dao
{
    public class tb_sys_ButtonDAL : BaseDAL<tb_sys_Button>, Itb_sys_ButtonDAL
    {

        public DataTable GetPageList(int page, int pagesize, out int total, string code, string disabled, List<WhereField> listWhere = null)
        {
            try
            {
                string where = "1=1";
                if (!string.IsNullOrEmpty(code))
                    where += " AND LEFT(ItemNo," + code.Length + ")='" + code + "'";
                if (!string.IsNullOrEmpty(disabled))
                    where += " AND IsDisabled=0";
                if (listWhere != null)
                {
                    foreach (WhereField item in listWhere)
                    {
                        if (item.Symbol == "like")
                            where += " and [" + item.Key + "] " + item.Symbol + " '%" + item.Value + "%'";
                        else
                            where += " and [" + item.Key + "] " + item.Symbol + " '" + item.Value + "'";
                    }
                }
                string sql = string.Format(@"SELECT  COUNT(1) CNT
                                               FROM  (SELECT ID
                                                            ,ItemNo
                                                            ,ItemName
                                                            ,ItemName DepName
                                                            ,ButtonText
                                                            ,ButtonIcon
                                                            ,IsDisabled
                                                      FROM   dbo.tb_sys_Button WHERE Marks=1
                                                    ) t WHERE {0} ", where);
                total = (int)DataProvider.DBHelper.ExecuteScalar(CommandType.Text, sql);
                sql = string.Format(@"SELECT  TOP({0})*
                                      FROM  (SELECT ROW_NUMBER() OVER (ORDER BY ItemNo) RowNo,*
                                             FROM   (SELECT ID
                                                            ,ItemNo
                                                            ,ItemName
                                                            ,ItemName DepName
                                                            ,ButtonText
                                                            ,ButtonIcon
                                                            ,IsDisabled
                                                            ,Remark
                                                      FROM   dbo.tb_sys_Button  WHERE Marks=1
                                                    ) t WHERE {1}
                                            ) tt WHERE RowNo>{2}", pagesize, where, (page - 1) * pagesize);
                return DataProvider.DBHelper.ExecuteDataTable(CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetModel(int id)
        {
            int total = 0;
            return GetPageList(1, 1, out total, "", "", new List<WhereField> { new WhereField("ID", id) });
        }
        //检测代码是否重复
        public int CheckItemNo(int id, string itemNo)
        {
            try
            {
                string sql = string.Format("SELECT COUNT(1)CNT FROM dbo.View_tb_sys_Item WHERE ID<>{0} AND NodeCode='{1}'", id, itemNo);
                return Convert.ToInt32(DataProvider.DBHelper.ExecuteScalar(CommandType.Text, sql));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteDepinfo(string id)
        {
            try
            {
                string sql = "UPDATE dbo.tb_sys_Button SET Marks=0 WHERE ID IN " + id + "";
                DataProvider.DBHelper.ExecuteNonQuery(CommandType.Text, sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
