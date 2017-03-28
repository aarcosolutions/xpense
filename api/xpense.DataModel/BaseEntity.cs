using System;

namespace xpense.DataModel
{
    public interface IAuditable
    {
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
        long? CreatedBy { get; set; }
        long? ModifiedBy { get; set; }
    }
}
