using System;

namespace xpense.DataModel
{
    public abstract class BaseEntity
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
