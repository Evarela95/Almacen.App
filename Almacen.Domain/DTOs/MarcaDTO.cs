﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.Domain.DTOs
{
    public class MarcaDTO
    {

        public MarcaDTO(int id_marca, string nombre_marca)
        {
            Id_Marca = id_marca;
            Nombre_Marca = nombre_marca;
        }

        public int Id_Marca { get; private set; }


        public string Nombre_Marca { get; private set; }
    }
}