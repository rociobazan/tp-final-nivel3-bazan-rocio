using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{

    public class FavoritoNegocio
    {
        public List<int> listarFavorito(int IdUser)
        {
            AccesoDatos datos = new AccesoDatos();
            List<int> lista = new List<int>();
            //List<Favoritos> listaFavoritos = new List<Favoritos>();
            

            try
            {
                //datos.setearConsulta("SELECT A.Id IdArt, A.Nombre, A.Precio, A.Descripcion , M.Descripcion Marca, C.Descripcion Categoria, F.Id FavoritoId from ARTICULOS A, MARCAS M, CATEGORIAS C, FAVORITOS F, USERS U where F.IdUser=U.Id AND F.IdArticulo=A.Id AND A.IdMarca=M.Id AND A.IdCategoria=C.Id AND U.Id=" + IdUser);
                datos.setearConsulta("SELECT IdArticulo from FAVORITOS where IdUser=@IdUser");
                datos.setearParametro("@IdUser", IdUser);
                datos.ejecutarLectura();



                while (datos.Lector.Read())
                {
                    int aux = (int)datos.Lector["IdArticulo"];
                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void agregarFavorito(int idUser, string idArt)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into FAVORITOS (IdUser, IdArticulo) values (@IdUser, @IdArt)");
                datos.setearParametro("@IdUser", idUser);
                datos.setearParametro("@IdArt", idArt);
                datos.ejecutarAccion();
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminarFavorito(string IdArt, int IdUser)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete from FAVORITOS where IdArticulo=@IdArt and IdUser=@IdUser");
                datos.setearParametro("@IdArt", IdArt);
                datos.setearParametro("@IdUser", IdUser);
                datos.ejecutarAccion ();
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion();}

        }


    }

}
