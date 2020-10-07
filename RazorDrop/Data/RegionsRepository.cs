﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RazorDrop.Data
{
    public class RegionsRepository
    {
        private readonly RazorDropContext _context;

        public RegionsRepository(RazorDropContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetRegions()
        {
            List<SelectListItem> regions = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = " "
                }
            };
            return regions;
        }

        public IEnumerable<SelectListItem> GetRegions(string countryId)
        {
            if (!String.IsNullOrWhiteSpace(countryId))
            {
                IEnumerable<SelectListItem> regions = _context.Regions.AsNoTracking()
                    .OrderBy(n => n.RegionNameEnglish)
                    .Where(n => n.CountryId == countryId)
                    .Select(n =>
                        new SelectListItem
                        {
                            Value = n.RegionId,
                            Text = n.RegionNameEnglish
                        }).ToList();
                return new SelectList(regions, "Value", "Text");
            }
            return null;
        }
    }
}
