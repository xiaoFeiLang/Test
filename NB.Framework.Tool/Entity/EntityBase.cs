using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NB.Framework.Tool.Entity
{
    /// <summary>
    /// 可持久到数据库的领域模型的基类。
    /// </summary>
    [Serializable]
    public abstract class EntityBase<TKey>
    {
        /// <summary>
        /// 数据实体基类
        /// </summary>
        protected EntityBase()
        {
            IsDeleted = false;
        }

        [Key]
        public TKey Id { get; set; }

        /// <summary>
        ///获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        public bool? IsDeleted { get; set; }
    }
}
