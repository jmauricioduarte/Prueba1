using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Entity;
using DAL;

namespace BLL
{
    public class GenerarPDF
    {
        string ruta = @"informe.pdf";
        PersonaService servicio = new PersonaService();
        public void GenerarPdf()
        {
           
            FileStream file = new FileStream(ruta, FileMode.Create);
            Document documento = new Document(PageSize.LETTER.Rotate(), 40, 40, 40, 40);
            documento.AddTitle("Mi Primer PDF");
            documento.AddCreator("Mauricio");

            PdfWriter.GetInstance(documento, file);

            documento.Open();

            documento.Add(new Paragraph("Persona Pulsaciones"));
            documento.Add(new Paragraph("\n\n"));
            documento.Add(LlenarTabla(servicio.Consultar()));

            documento.Close();


        }

        public PdfPTable LlenarTabla(List<Persona> empleados)
        {
            PdfPTable tabla = new PdfPTable(6);

            tabla.AddCell(new Paragraph("Identificacion"));
            tabla.AddCell(new Paragraph("Nombre"));
            tabla.AddCell(new Paragraph("Edad"));
            tabla.AddCell(new Paragraph("Sexo"));
            tabla.AddCell(new Paragraph("Pulsaciones"));

            foreach (var item in empleados)
            {

                tabla.AddCell($"{item.Identificacion}");
                tabla.AddCell($"{item.Nombre}");
                tabla.AddCell($"{item.Edad}");
                tabla.AddCell($"{item.Sexo}");
                tabla.AddCell($"{item.Pulsaciones}");
            }

            return tabla;
        }
    }
}
