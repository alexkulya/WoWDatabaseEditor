﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shaolinq;
using WDE.Common.Database;

namespace WDE.TrinityMySqlDatabase.Models
{
    [DataAccessObject(Name = "gameobject_template")]
    public abstract class MySqlGameObjectTemplate : DataAccessObject, IGameObjectTemplate
    {
        [PrimaryKey]
        [PersistedMember(Name = "entry")]
        public abstract uint Entry { get; set; }

        [PersistedMember(Name = "name")]
        public abstract string Name { get; set; }
    }
}
