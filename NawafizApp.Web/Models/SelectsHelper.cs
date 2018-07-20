using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NawafizApp.Web.Models
{
    public static class SelectsHelper
    {
        public static IList<SelectListItem> Directions(int? selected)
        {
            var service = DependencyResolver.Current.GetService<IAuctionService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.getAllDirections()
                              .ToList().OrderByDescending(x => x.Id)

                              .Select(x => new SelectListItem
                              {
                              
                                  Text = x.name,
                                  Value = x.name.ToString()
                              })
                              .ToList());

            return list;
        }
        public static IList<SelectListItem> Decorations(int? selected)
        {
            var service = DependencyResolver.Current.GetService<IAuctionService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.getAllDecorations()
                              .ToList().OrderByDescending(x => x.Id)

                              .Select(x => new SelectListItem
                              {
                                  Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                  Text = x.type,
                                  Value = x.Id.ToString()
                              })
                              .ToList());

            return list;
        }
        public static IList<SelectListItem> Floors(int? selected)
        {
            var service = DependencyResolver.Current.GetService<IAuctionService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.getAllFloors()
                              .ToList().OrderByDescending(x => x.Id)

                              .Select(x => new SelectListItem
                              {
                                  Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                  Text = x.number.ToString(),
                                  Value = x.Id.ToString()
                              })
                              .ToList());

            return list;
        }
        public static IList<SelectListItem> H_Views(int? selected)
        {
            var service = DependencyResolver.Current.GetService<IAuctionService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.getAllH_Views()
                              .ToList().OrderByDescending(x => x.Id)

                              .Select(x => new SelectListItem
                              {
                                  Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                  Text = x.name.ToString(),
                                  Value = x.Id.ToString()
                              })
                              .ToList());

            return list;
        }
        public static IList<SelectListItem> Locations(int? selected)
        {
            var service = DependencyResolver.Current.GetService<IAuctionService>();

            var list = new List<SelectListItem>
                           {
                               new SelectListItem
                                   {
                                       Selected = !selected.HasValue,
                                       Text = String.Empty,
                                       Value=""
                                   }
                           };

            list.AddRange(service.getAllLocations()
                              .ToList().OrderByDescending(x => x.Id)

                              .Select(x => new SelectListItem
                              {
                                  Selected = x.Id == (selected.HasValue ? selected.Value : -1),
                                  Text = x.name.ToString(),
                                  Value = x.Id.ToString()
                              })
                              .ToList());

            return list;
        }
    }
}