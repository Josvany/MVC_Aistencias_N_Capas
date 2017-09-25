using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class Use_Inf_Bll
    {

        public static List<User_Info_Entity> Listar(Guid Use_Inf_Int_Id)
        {
            return Use_Inf_Dal.Listar(Use_Inf_Int_Id);
        }

        public static bool Create(User_Info_Entity ObjuserInf)
        {
            return Use_Inf_Dal.Create(ObjuserInf);
        }
    }
}
