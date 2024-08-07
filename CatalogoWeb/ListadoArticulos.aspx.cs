﻿using Dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb
{
    public partial class ListadoArticulos : System.Web.UI.Page
    {
        public bool filtroAvanzado {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (!Seguridad.esAdmin(Session["Usuario"]))
                {
                    Session.Add("Error", "Debes ser administrador para ingresar aquí");
                    Response.Redirect("Error.aspx", false);
                }
                
                Session.Add("listaArticulos", negocio.listar());
                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();


            }
            catch (Exception ex)
            {
                Session.Add("Error", Seguridad.manejoDeError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAgregarNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioArticulos.aspx", false);
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string id = dgvArticulos.SelectedDataKey.Value.ToString();
                Response.Redirect("FormularioArticulos.aspx?id=" + id, false);
            }
            catch(Exception ex)
            {
                Session.Add("Error", Seguridad.manejoDeError(ex));
                Response.Redirect("Error.aspx", false);
            }
                
                
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
                List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtSearch.Text.ToUpper()));
                dgvArticulos.DataSource = listaFiltrada;
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", Seguridad.manejoDeError(ex));
                Response.Redirect("Error.aspx", false);
            }
            
            
            
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", Seguridad.manejoDeError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void cbxFiltro_CheckedChanged(object sender, EventArgs e)
        {
            filtroAvanzado = cbxFiltro.Checked;
            txtSearch.Enabled = !filtroAvanzado;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvArticulos.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text);
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", Seguridad.manejoDeError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}