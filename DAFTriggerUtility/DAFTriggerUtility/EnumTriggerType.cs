using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAFTriggerUtility
{
  public  enum EnumTriggerType
    {
         RowBeforeInsert = 1,
         RowAfterInsert =2,
         RowBeforeUpdate =3,
         RowAfterUpdate = 4,
         RowBeforeDelete =5,
         RowAfterDelete = 6,
         StatementBeforeInsert =7,
         StatementAfterInsert = 8,
         StatementBeforeUpdate = 9,
         StatementAfterUpdate =10,
         StatementBeforeDelete = 11,
         StatementAfterDelete = 12
    }
}
