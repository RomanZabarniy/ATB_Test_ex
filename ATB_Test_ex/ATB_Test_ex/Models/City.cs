﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATB_Test_ex.Models.Domain.Entity
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
    }
}