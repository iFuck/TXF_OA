﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IBLL
{
    public interface Itb_sys_ItemBLL : IBaseBLL<tb_sys_Item>
    {
        DataTable SelectTreeList(string url);
        string GetTabelName(string code);
        int GetMaxLevel();
        bool CheckNodeType(int type);
        void UpdateChildNode(string code, string preCode, string tableName);
        void UpdateNodeState(int id, string state);
        void DeleteByNodeCode(string code);
    }
}
