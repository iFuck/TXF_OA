﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Model;

namespace IDao
{
    public interface Itb_sys_ModuleDAL : IBaseDAL<tb_sys_Module>
    {
        void SaveModule(tb_sys_Module module, string code);
        /// <summary>
        /// 更新树形节点状态
        /// </summary>
        void UpdateNodeState(string state, int id);
        /// <summary>
        /// 根据权限获取菜单
        /// </summary>
        /// <param name="roleID"></param>
        DataTable GetModuleByRoleID(string where);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteModule(string code);
        /// <summary>
        /// 获得分页数据
        /// </summary>
        DataTable GetPageList(int page, int pagesize, out int total, string code, List<WhereField> listWhere = null);
    }
}
