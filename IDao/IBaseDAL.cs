﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Linq.Expressions;
using Model;

namespace IDao
{
    public interface IBaseDAL<T> where T : class,new()
    {
        /// <summary>
        /// 绑定Mode实体类
        /// </summary>
        T BindModel();
        /// <summary>
        /// 新增一条记录
        /// </summary>
        int Add(T entity);
        /// <summary>
        /// 根据主键修改记录
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
        /// <summary>
        /// 根据where条件修改指定字段
        /// </summary>
        /// <param name="listField"></param>
        /// <param name="listWhere"></param>
        void Update(List<UpdateField> listField, List<WhereField> listWhere);
        /// <summary>
        /// 根据where条件修改指定字段
        /// </summary>
        /// <param name="listField">需要跟新的字段集合</param>
        /// <param name="where">where条件字符串</param>
        void Update(List<UpdateField> listField, string where);
        /// <summary>
        /// 根据实体类主键删除记录
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
        /// <summary>
        /// 根据where条件删除记录
        /// </summary>
        /// <param name="where"></param>
        void Delete(string where);
        /// <summary>
        /// 根据List<where>条件删除记录
        /// </summary>
        /// <param name="listWhere"></param>
        void Delete(List<WhereField> listWhere);
        /// <summary>
        /// 查找单个实体类
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        T SelectEntity(string where);
        /// <summary>
        /// 查找实体类集合
        /// </summary>
        /// <param name="field"></param>
        /// <param name="where"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        List<T> SelectList(string field = "", string where = "", string sort = "");
        /// <summary>
        /// 查找实体类集合
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="sort"></param>
        /// <param name="field"></param>
        /// <param name="listWhere"></param>
        /// <returns></returns>
        List<T> SelectList(string field = "", List<WhereField> listWhere = null, string sort = "");
        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="field"></param>
        /// <param name="where"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        DataTable SelectDataTable(string field = "", string where = "", string sort = "");
        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="sort"></param>
        /// <param name="field"></param>
        /// <param name="listWhere"></param>
        /// <returns></returns>
        DataTable SelectDataTable(string field = "", List<WhereField> listWhere = null, string sort = "");
        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int SelectCount(string where = "");
        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <param name="listWhere"></param>
        /// <returns></returns>
        int SelectCount(List<WhereField> listWhere);
    }
}
