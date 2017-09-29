using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Capa_Conexion;
using System.Data;

namespace DAL
{
    public class Product_Dal
    {
        public static List<Product_Entity> Listar()
        {

            var objProd = new List<Product_Entity>();
            try
            {
                Conexion.IniciarSesion();

                var dtp = Conexion.GDatos.TraerDataTable("SP_Listar", "TBL_PRODUCTO");
                var dtCat = Conexion.GDatos.TraerDataTable("SP_Listar", "CAT_CATEGORIA");

                var Inner = (from DtPro in dtp.AsEnumerable()
                            join DtCat in dtCat.AsEnumerable() on DtPro.Field<Guid>("Cat_Int_Id") equals DtCat.Field<Guid>("Cat_Int_Id")
                            select new {
                                PROD_INT_ID = DtPro.Field<Guid>("PROD_INT_ID"),
                                PROD_NOMBRE = DtPro.Field<string>("PROD_NOMBRE"),
                                PROD_SYS_NAME = DtPro.Field<string>("PROD_SYS_NAME"),
                                PROD_PRE_V = DtPro.Field<decimal>("PROD_PRE_V"),
                                PROD_PRE_C = DtPro.Field<decimal>("PROD_PRE_C"),
                                PROD_CANT = DtPro.Field<int>("PROD_CANT"),
                                CAT_INT_ID = DtPro.Field<Guid>("CAT_INT_ID"),
                                PROD_STATUS = DtPro.Field<bool>("PROD_STATUS"),
                                PROD_IMAGE = DtPro.Field<byte[]>("PROD_IMAGE"),
                                Name = DtCat.Field<string>("CAT_NOMBRE")
                            }).ToList();

                foreach (var item in Inner)
                {
                    objProd.Add(new Product_Entity
                    {
                        Prod_Int_Id = (Guid)(item.PROD_INT_ID),
                        Prod_Name = item.PROD_NOMBRE.ToString(),
                        Prod_System_Name = item.PROD_SYS_NAME,
                        Prod_Sale_P = decimal.Parse(item.PROD_PRE_V.ToString()),
                        Prod_P_C = decimal.Parse(item.PROD_PRE_C.ToString()),
                        Prod_Cant = (int)item.PROD_CANT,
                        Cat_Int_Id = (Guid)item.CAT_INT_ID,
                        Prod_Status = (bool)item.PROD_STATUS,
                        Prod_Img = (byte[])item.PROD_IMAGE,
                        Cat_Name = item.Name.ToString()
                    });
                }
            }
            catch (Exception)
            {
                Conexion.FinalizarSesion();
                throw;
            }
            
            return objProd;
        }

        public static List<Product_Entity> ListarByCat(Guid idcat)
        {

            var objProd = new List<Product_Entity>();
            try
            {
                Conexion.IniciarSesion();

                var dt = Conexion.GDatos.TraerDataTable("SP_Listar", "TBL_PRODUCTO");


                var row = (from Pro in dt.AsEnumerable()
                           where Pro.Field<Guid>("CAT_INT_ID") == idcat
                           select Pro).ToList();


                var dtCat = Conexion.GDatos.TraerDataTable("SP_Listar", "CAT_CATEGORIA");

                var Inner = (from DtPro in row.AsEnumerable()
                             join DtCat in dtCat.AsEnumerable() on DtPro.Field<Guid>("Cat_Int_Id") equals DtCat.Field<Guid>("Cat_Int_Id")
                             select new
                             {
                                 PROD_INT_ID = DtPro.Field<Guid>("PROD_INT_ID"),
                                 PROD_NOMBRE = DtPro.Field<string>("PROD_NOMBRE"),
                                 PROD_SYS_NAME = DtPro.Field<string>("PROD_SYS_NAME"),
                                 PROD_PRE_V = DtPro.Field<decimal>("PROD_PRE_V"),
                                 PROD_PRE_C = DtPro.Field<decimal>("PROD_PRE_C"),
                                 PROD_CANT = DtPro.Field<int>("PROD_CANT"),
                                 CAT_INT_ID = DtPro.Field<Guid>("CAT_INT_ID"),
                                 PROD_STATUS = DtPro.Field<bool>("PROD_STATUS"),
                                 PROD_IMAGE = DtPro.Field<byte[]>("PROD_IMAGE"),
                                 Name = DtCat.Field<string>("CAT_NOMBRE")
                             }).ToList();

                foreach (var item in Inner)
                {
                    objProd.Add(new Product_Entity
                    {
                        Prod_Int_Id = (Guid)(item.PROD_INT_ID),
                        Prod_Name = item.PROD_NOMBRE.ToString(),
                        Prod_System_Name = item.PROD_SYS_NAME,
                        Prod_Sale_P = decimal.Parse(item.PROD_PRE_V.ToString()),
                        Prod_P_C = decimal.Parse(item.PROD_PRE_C.ToString()),
                        Prod_Cant = (int)item.PROD_CANT,
                        Cat_Int_Id = (Guid)item.CAT_INT_ID,
                        Prod_Status = (bool)item.PROD_STATUS,
                        Prod_Img = (byte[])item.PROD_IMAGE,
                        Cat_Name = item.Name.ToString()
                    });
                }
            }
            catch (Exception)
            {
                Conexion.FinalizarSesion();
                throw;
            }

            return objProd;
        }


        public static Product_Entity Listar(Guid idProd)
        {
            var objPro = new Product_Entity();
            try
            {
                //var dt = Conexion.GDatos.TraerDataTable("",idCat);
                DataTable dt = Conexion.GDatos.TraerDataTable("SP_Listar", "TBL_PRODUCTO");
                var row = (from Pro in dt.AsEnumerable()
                           where Pro.Field<Guid>("PROD_INT_ID") == idProd
                           select Pro).ToList();
                if (row.Count > 0)
                {
                    objPro.Prod_Int_Id = (Guid)row[0].ItemArray[0];
                    objPro.Prod_Name = row[0].ItemArray[1].ToString();
                    objPro.Prod_System_Name = row[0].ItemArray[2].ToString();
                    objPro.Prod_Sale_P = (decimal)row[0].ItemArray[3];
                    objPro.Prod_P_C = (decimal)row[0].ItemArray[4];
                    objPro.Prod_Cant = (int)row[0].ItemArray[5];
                    objPro.Cat_Int_Id = (Guid)row[0].ItemArray[6];
                    objPro.Prod_Status = (bool)row[0].ItemArray[7];
                    objPro.Prod_Img = (byte[])row[0].ItemArray[8];

                }
            }
            catch (Exception)
            {

                throw;
            }
            return objPro;
        }


        public static bool Create(Product_Entity ObjProduct)
        {
            bool flag = false;

            try
            {
                Conexion.GDatos.Ejecutar("SP_IM_PRODUCTO", ObjProduct.Prod_Int_Id, ObjProduct.Prod_Name, ObjProduct.Prod_System_Name, ObjProduct.Prod_Sale_P, ObjProduct.Prod_P_C, ObjProduct.Prod_Cant,
                                         ObjProduct.Cat_Int_Id, ObjProduct.Prod_Status, ObjProduct.Prod_Img);
                flag = true;
            }
            catch (Exception)
            {
                throw;
            }

            return flag;
        }
    }
}
