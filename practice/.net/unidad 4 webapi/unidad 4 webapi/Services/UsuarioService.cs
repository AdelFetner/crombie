﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using unidad_4_webapi.Servicios;
using unidad_4_webapi.Models;
using unidad_4_webapi.Data;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;

namespace unidad_4_webapi.Servicios
{
    public class UsuarioService
    {
        List<Usuario> usuariosList;
        // Especifica la ruta relativa del archivo Excel
        string filePath = "BibliotecaBaseDatos.xlsx";
        List<Usuario> dataList;

        public UsuarioService()
        {
            usuariosList = new UsuarioData().usuariosList;
            var dataList = new List<Usuario>();
        }
        public List<Usuario> ObtenerUsuarios()
        {
            using (var workbook = new XLWorkbook(filePath))
            {

                // Selecciona la primera hoja del archivo.
                var worksheet = workbook.Worksheet(1);

                // Encuentra la última fila utilizada en la hoja.
                int lastRowUsed = worksheet.LastRowUsed().RowNumber();

                // Recorre cada fila de datos, comenzando desde la segunda fila (omitiendo los encabezados).
                for (int row = 3; row <= lastRowUsed; row++)
                {
                    // Crea una instancia de Excel y asigna valores a sus propiedades desde las celdas de la fila actual.
                    var dataItem = new Usuario
                    {
                        IDUsuario = worksheet.Cell(row, 1).GetValue<string>(),
                        Nombre = worksheet.Cell(row, 2).GetValue<string>(),
                        TipoUsuario = worksheet.Cell(row, 3).GetValue<string>(),
                        LibrosPrestados = worksheet.Cell(row, 4).GetValue<string>()
                    };
                    dataList.Add(dataItem);
                }
                return dataList;
            }
        }

        public List<Usuario> InsertarUsuarios(List<Usuario> NuevosUsuarios)
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);
                int lastRowUsed = worksheet.LastRowUsed().RowNumber();

                foreach (var usuario in NuevosUsuarios)
                {
                    lastRowUsed++; // Mueve a la siguiente fila disponible

                    // Inserta los valores en las columnas correspondientes de la nueva fila
                    worksheet.Cell(lastRowUsed, 1).Value = Int32.Parse(usuario.IDUsuario);
                    worksheet.Cell(lastRowUsed, 2).Value = usuario.Nombre;
                    worksheet.Cell(lastRowUsed, 3).Value = usuario.TipoUsuario;
                    worksheet.Cell(lastRowUsed, 4).Value = usuario.LibrosPrestados;
                }

                workbook.Save();
            }
            return NuevosUsuarios;
        }

        public Usuario? BuscarUsuarioPorId(string id)
        {
            return usuariosList.Find(u => u.IDUsuario == id);
        }


        public string ActualizarUsuario(string id, Usuario usuario)
        {
            var usuarioExistente = BuscarUsuarioPorId(id);
            if (usuarioExistente == null)
                throw new ArgumentException("Usuario no encontrado");

            usuarioExistente.Nombre = usuario.Nombre;
            return "Usuario actualizado exitosamente";
        }

        public string EliminarUsuario(string id)
        {
            var usuario = BuscarUsuarioPorId(id);
            if (usuario == null)
                throw new ArgumentException("Usuario no encontrado");

            if (usuario.LibrosPrestados.Any())
                throw new InvalidOperationException("No se puede eliminar un usuario con libros prestados");

            usuariosList.Remove(usuario);
            return "Usuario eliminado exitosamente";
        }
    }
}