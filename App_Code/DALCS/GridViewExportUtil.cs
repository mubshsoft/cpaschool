﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.IO;


namespace fmsf.lib
{

  public class GridViewExportUtil
        {

            public static void Export(string fileName, GridView gv)
            {
                try
                {
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
                    HttpContext.Current.Response.ContentType = "application/ms-excel";

                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                        {
                            //  Create a form to contain the grid
                            Table table = new Table();

                            //  add the header row to the table
                            if (gv.HeaderRow != null)
                            {
                                GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                                table.Rows.Add(gv.HeaderRow);
                            }

                            //  add each of the data rows to the table
                            foreach (GridViewRow row in gv.Rows)
                            {
                                GridViewExportUtil.PrepareControlForExport(row);
                                table.Rows.Add(row);
                            }

                            //  add the footer row to the table
                            if (gv.FooterRow != null)
                            {
                                GridViewExportUtil.PrepareControlForExport(gv.FooterRow);
                                table.Rows.Add(gv.FooterRow);
                            }

                            //  render the table into the htmlwriter
                            table.RenderControl(htw);

                            //  render the htmlwriter into the response
                            HttpContext.Current.Response.Write(sw.ToString());
                            HttpContext.Current.Response.End();
                        }
                    }
                }
                catch (Exception ex)
                {
                    HandleException.ExceptionLogging(ex.Source, ex.Message, true);

                }
            }

            /// <summary>
            /// Replace any of the contained controls with literals
            /// </summary>
            /// <param name="control"></param>
            private static void PrepareControlForExport(Control control)
            {
                try
                {
                    for (int i = 0; i < control.Controls.Count; i++)
                    {
                        Control current = control.Controls[i];
                        if (current is LinkButton)
                        {
                            control.Controls.Remove(current);
                            control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
                        }
                        else if (current is ImageButton)
                        {
                            control.Controls.Remove(current);
                            control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
                        }
                        else if (current is HyperLink)
                        {
                            control.Controls.Remove(current);
                            control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
                        }
                        else if (current is DropDownList)
                        {
                            control.Controls.Remove(current);
                            control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
                        }
                        else if (current is CheckBox)
                        {
                            control.Controls.Remove(current);
                            control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
                        }

                        if (current.HasControls())
                        {
                            GridViewExportUtil.PrepareControlForExport(current);
                        }
                    }
                }
                catch (Exception ex)
                {
                    HandleException.ExceptionLogging(ex.Source, ex.Message, true);

                }
            }

            public static void ExportToExcel(string fileName, GridView gv)
            {
                string attachment = "attachment; filename=" + fileName;
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.AddHeader("content-disposition", attachment);
                HttpContext.Current.Response.ContentType = "application/ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);

                // Create a form to contain the grid
                HtmlForm frm = new HtmlForm();
                gv.Parent.Controls.Add(frm);
                frm.Attributes["runat"] = "server";


                try
                {
                    frm.Controls.Add(gv);
                }
                catch (Exception exx)
                {
                }

                try
                {
                    frm.RenderControl(htw);
                }
                catch (Exception exx)
                {
                }

                //GridView1.RenderControl(htw);
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }

            public static void ExportToWord(string fileName, GridView gv)
            {
                string attachment = "attachment; filename=" + fileName;
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.AddHeader("content-disposition", attachment);
                HttpContext.Current.Response.ContentType = "application/ms-word";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);

                // Create a form to contain the grid
                HtmlForm frm = new HtmlForm();
                gv.Parent.Controls.Add(frm);
                frm.Attributes["runat"] = "server";


                try
                {
                    frm.Controls.Add(gv);
                }
                catch (Exception exx)
                {
                }

                try
                {
                    frm.RenderControl(htw);
                }
                catch (Exception exx)
                {
                }

                //GridView1.RenderControl(htw);
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }
    
}
