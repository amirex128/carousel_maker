using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using carousel_maker.Models;
using carousel_maker.ModelView;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;

namespace carousel_maker.Controllers;

public class CarouselController : Controller
{
    public IActionResult Input()
    {
        return View();
    }

    public IActionResult Save(InputJsonCarouselModel model)
    {
        try
        {
            var titleDict = JsonConvert.DeserializeObject<List<Carousel>>(model.Json);
            string jsonLog = JsonConvert.SerializeObject(titleDict);
            System.IO.File.WriteAllText("jos.json", jsonLog);
        }
        catch (Exception ex)
        {
            return NotFound();
        }


        return RedirectToAction("Make");
    }

    public IActionResult Make()
    {
        IList<Carousel> carousels = new List<Carousel>();

        var jsonData = System.IO.File.ReadAllText("jos.json");
        carousels = JsonConvert.DeserializeObject<List<Carousel>>(jsonData);
        var text = "";
        foreach (var carousel in carousels)
        {
            text += carousel.Title + Environment.NewLine;
            text += carousel.Body + Environment.NewLine;
            text += "Example:" + carousel.Example + Environment.NewLine;
            text += carousel.HashTag + Environment.NewLine;
            text += Environment.NewLine; // Add an empty line between carousel entries
        }

        return View(new CarouselViewModel()
        {
            Text = text,
            Content = carousels
        });
    }
}