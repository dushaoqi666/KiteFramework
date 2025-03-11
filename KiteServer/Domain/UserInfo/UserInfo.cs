﻿namespace Domain.UserInfo
{
    using SqlSugar;

    [SugarTable("user_info")]
    public class UserInfo : Entity, IAutoGenerated
    {
        
        /// <summary>
        /// 用户名
        /// </summary>
        [SugarColumn(ColumnName = "name", Length = 50)]
        public string Name { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [SugarColumn(ColumnName = "nick_name", Length = 50)]
        public string NickName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [SugarColumn(ColumnName = "pass_word", Length = 50)]
        public string PassWord { get; set; }

        /// <summary>
        /// 钉钉用户ID
        /// </summary>
        [SugarColumn(ColumnName = "ding_user_id", Length = 50)]
        public string DingUserId { get; set; }

        /// <summary>
        /// 状态(0正常，1禁用)
        /// </summary>
        [SugarColumn(ColumnName = "status", Length = 2)]
        public string? Status { get; private set; }

        public UserInfo()
        {
        }

        /// <summary>
        /// 用户实体
        /// </summary>
        public UserInfo(string name, string nickName, string passWord, string dingUserId)
        {
            Name = name;
            NickName = nickName;
            PassWord = passWord;
            DingUserId = dingUserId;
            Status = "0";
        }
    }
}