using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace TravelClient.Controllers
{
  public class ReviewsController : Controller
  {
    public IActionResult Index()
    {
      var allReviews = Review.GetReviews();
      return View(allReviews);
    }

    //[Route("reviews/details/{id}")]
    public IActionResult Details(int id)
    {
      var thisReview = Review.GetDetails(id);
      return View(thisReview);
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Review review)
    {
      Review.Post(review);
      return RedirectToAction("Details", new { id = review.ReviewId });
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
      Review review = Review.GetDetails(id);
      return View(review);
    }

    [HttpPost]
    public IActionResult Update(Review review)
    {
      Review.Put(review);
      return RedirectToAction("Details", new { id = review.ReviewId });
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
      Review review = Review.GetDetails(id);
      return View(review);
    }

    [HttpPost]
    public IActionResult Delete(Review review)
    {
      Review.Delete(review.ReviewId);
      return RedirectToAction("Index");
    }
  }
}