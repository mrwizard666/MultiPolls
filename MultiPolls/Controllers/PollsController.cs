﻿﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MultiPolls.Models;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Helpers;
using System.Drawing;
using DotNet.Highcharts.Enums;
using Microsoft.AspNet.Identity;
using MultiPolls.ViewModels;

namespace MultiPolls.Controllers
{
    public class PollsController : Controller
    {
        private PollDBContext db = new PollDBContext();

     
        // GET: /Polls/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Polls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CreationDate,EditDate,CreatorID,PollQuestion,OptionA,OptionB,OptionC,OptionD,OptionE,OptionF,OptionG,OptionH,OptionI,OptionJ,IsPublished,IsPublic,HasVoted")] Poll poll)
        {
            if (ModelState.IsValid)
            {
                poll.CreatorID = User.Identity.Name;
                poll.CreationDate = DateTime.Now;
                poll.EditDate = DateTime.Now;
                poll.IsPublished = false;
                poll.IsPublic = false;
                poll.HasVoted = false;
                poll.UsernameVisible = false;
                db.Polls.Add(poll);
                db.SaveChanges();
                return RedirectToAction("/MyPolls");
            }
            return View(poll);
        }

        // GET: /Polls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poll poll = db.Polls.Find(id);
           
            if (poll == null)
            {
                return HttpNotFound();
            }
            return View(poll);
        }

        // POST: /Polls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CreationDate,EditDate,CreatorID,PollQuestion,OptionA,OptionB,OptionC,OptionD,OptionE,OptionF,OptionG,OptionH,OptionI,OptionJ")] Poll poll)
        {
            if (ModelState.IsValid)
            {
                poll.CreatorID = User.Identity.Name;
                poll.EditDate = DateTime.Now;
                poll.CreationDate = DateTime.Now;
                poll.IsPublished = false;
                poll.IsPublic = false;
                poll.HasVoted = false;
                poll.UsernameVisible = false;
                db.Entry(poll).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("/MyPolls");
            }
            return View(poll);
        }


        //GET: /Polls/Publish/5
        public ActionResult Publish(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poll poll = db.Polls.Find(id);
            if (poll == null)
            {
                return HttpNotFound();
            }
            return View(poll);
        
        }

        // POST: /Polls/Publish/5
        [HttpPost, ActionName("Publish")]
        [ValidateAntiForgeryToken]
        public ActionResult PublishConfirmed(int id, bool? Check)
        {
            Poll poll = db.Polls.Find(id);
            if (Check == false)
            {
                poll.UsernameVisible = false;
            }
            else
            {
                poll.UsernameVisible = true;
            }
            poll.IsPublic = true;
            poll.IsPublished = true;
            db.SaveChanges();
            return RedirectToAction("/MyPolls");
        }

        // GET: /Polls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poll poll = db.Polls.Find(id);
            if (poll == null)
            {
                return HttpNotFound();
            }
            return View(poll);
        }

        // POST: /Polls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poll poll = db.Polls.Find(id);
            db.Polls.Remove(poll);
            db.SaveChanges();
            return RedirectToAction("/MyPolls");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: /Polls/
        public ActionResult MyPolls()
        {
            PollDBContext db = new PollDBContext();

            var creatorID = from c in db.Polls
                            where c.CreatorID == User.Identity.Name
                            select c;

            return View(creatorID.ToList());
        }


        // GET: /Polls/PublicPolls
        public ActionResult PublicPolls()
        {
            //Split into partial views

            //PollDBContext db = new PollDBContext();

            //var voteDetails = from u in db.Polls
            //                  join v in db.VoteLogs
            //                  on u.ID equals v.QuestionID
            //                  into uv
            //                  from v in uv
            //                  where v.QuestionID == u.ID && v.User == User.Identity.Name
            //                  select uv

            //return View(voteDetails.ToList());
            return View(db.Polls.ToList());

        }


        // GET: /Polls/Vote
        public ActionResult Vote(int? id)
        {
            Poll poll = db.Polls.Find(id);
            //if (poll.HasVoted == true)
            //{
            //    return RedirectToAction("MyPolls");
            //}
            //else
            //{
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                if (poll == null)
                {
                    return HttpNotFound();
                }
                return View(poll);
            //}
        }

        // POST: /Polls/Vote/4
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(int? id, string Option, [Bind(Include = "ID,CreationDate,EditDate,CreatorID,PollQuestion,OptionA,OptionB,OptionC,OptionD,OptionE,OptionF,OptionG,OptionH,OptionI,OptionJ, HasVoted")] Poll poll, [Bind(Include = "User, QuestionID")] VoteLog vote )
        {
            if (ModelState.IsValid)
            {
                //for (char c1 = 'A'; c1 <= 'J'; c1++)
                //{
                poll = db.Polls.Find(id);
                vote.QuestionID = poll.ID;
                vote.User = User.Identity.Name;
                poll.HasVoted = true;
                db.VoteLogs.Add(vote);

                if (Option == "A")
                    poll.AnswerA = poll.AnswerA + 1;
                else if (Option == "B")
                    poll.AnswerB = poll.AnswerB + 1;
                else if (Option == "C")
                    poll.AnswerC = poll.AnswerC + 1;
                else if (Option == "D")
                    poll.AnswerD = poll.AnswerD + 1;
                else if (Option == "E")
                    poll.AnswerE = poll.AnswerE + 1;
                else if (Option == "F")
                    poll.AnswerF = poll.AnswerF + 1;
                else if (Option == "G")
                    poll.AnswerG = poll.AnswerG + 1;
                else if (Option == "H")
                    poll.AnswerH = poll.AnswerH + 1;
                else if (Option == "I")
                    poll.AnswerI = poll.AnswerI + 1;
                else if (Option == "J")
                    poll.AnswerJ = poll.AnswerJ + 1;

                db.SaveChanges();
                return RedirectToAction("PollResults/" + id);
            }
            return View(poll);
        }

        // GET: /Polls/PollResults
        public ActionResult PollResults(int? id, Poll poll)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            poll = db.Polls.Find(id);
            //if (poll.OptionC != null)
            //    var objectC = {poll.OptionC, poll.AnswerC};


            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart");

            chart.InitChart(new DotNet.Highcharts.Options.Chart
            {
                DefaultSeriesType = ChartTypes.Column,
                Width = 600,
                Height = 400,
                //Events = new ChartEvents { Click = "ChartClickEvent" }
            })
            .SetSeries(new Series
            {
                Type = ChartTypes.Pie,
                Name = "Opinions",
                Data = new Data(new object[]
                {
                     //for (char c1 = 'A'; c1 <= 'J'; c1++)
                //{
                    new object[] { poll.OptionA, poll.AnswerA },
                    new object[] { poll.OptionB, poll.AnswerB },
                    new object[] { poll.OptionC, poll.AnswerC },
                    new object[] { poll.OptionD, poll.AnswerD },
                    //new object[] { poll.OptionE, poll.AnswerE },
                    //new object[] { poll.OptionF, poll.AnswerF },
                    //new object[] { poll.OptionG, poll.AnswerG },
                    //new object[] { poll.OptionH, poll.AnswerH },
                    //new object[] { poll.OptionI, poll.AnswerI },
                    //new object[] { poll.OptionJ, poll.AnswerJ },
               
                })
            });
            chart.SetTitle(new Title { Text = "Opinions" });


            //poll = db.Polls.Find(id);
            if (poll == null)
            {
                return HttpNotFound();
            }
            return View(chart);
        }
    }
}





//            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart");

//            chart.InitChart(new DotNet.Highcharts.Options.Chart
//            {
//                DefaultSeriesType = ChartTypes.Column,
//                Width = 600,
//                Height = 400,
//                //Events = new ChartEvents { Click = "ChartClickEvent" }
//            })
//            .SetSeries(new Series
//            {
//                Type = ChartTypes.Pie,
//                Name = "Test pie chart",
//                Data = new Data(new object[]
//                {
                    
                    
//                    new object[] { poll.OptionA, poll.AnswerA },
//                    new object[] { poll.OptionB, poll.AnswerB },
//                    //new DotNet.Highcharts.Options.Point
//                    //{
//                    //    Name = "Chrome",
//                    //    Y = 12.8,
//                    //    Sliced = true,
//                    //    Selected = true
//                    //},
//                    //new object[] { "Safari", 8.5 },
//                    //new object[] { "Opera", 6.2 },
//                    //new object[] { "Others", 0.7 }
//                })
//            });
//            chart.SetTitle(new Title {Text = "MrWizards Chart"});
            
            
//            //poll = db.Polls.Find(id);
//            if (poll == null)
//            {
//                return HttpNotFound();
//            }
//            return View(chart);
//        }
//    }
//}



////Maybe useful info
////-----------------------------//
////.SetTitle(new Title 
////{ 
////    Text = "MrWizard's Chart" 
////});

////.AddJavascripFunction("ChartClickEvent", @"$.get('signup/signup')")
////.SetCredits(new Credits { Enabled = false })
////.SetTitle(new Title { Text = "Sign ups" });

////chart.InitChart(new Chart
////    {
////        BorderWidth = 0,
////        BorderRadius = 15,
////        PlotBackgroundColor = null,
////        PlotShadow = false,
////        PlotBorderWidth = 0,
////        Events = new ChartEvents { Click = "@Navigate()" },
////        BackgroundColor = new BackColorOrGradient(new Gradient
////        {
////            LinearGradient = new[] { 0, 0, 0, 400 },
////            Stops = new object[,]
////           {
////               { 0, Color.FromArgb(255, 96, 96, 96) },
////               { 1, Color.FromArgb(255, 16, 16, 16) }
////           }
////        }),
////    })
////    .SetCredits(new Credits { Enabled = false })
////    .SetOptions(new GlobalOptions
////    {
////        Colors = new[]
////       {
////        ColorTranslator.FromHtml("#DDDF0D"),
////        ColorTranslator.FromHtml("#7798BF"),
////        ColorTranslator.FromHtml("#55BF3B"),
////        ColorTranslator.FromHtml("#DF5353"),
////        ColorTranslator.FromHtml("#DDDF0D"),
////        ColorTranslator.FromHtml("#aaeeee"),
////        ColorTranslator.FromHtml("#ff0066"),
////        ColorTranslator.FromHtml("#eeaaee")
////       }
////    })
////    .SetTitle(new Title { Text = "Devices Not Responding", Style = "color: '#FFF', font: '16px Lucida Grande, Lucida Sans Unicode, Verdana, Arial, Helvetica, sans-serif'" })
////    .SetTooltip(new Tooltip { Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }" })
////    .SetPlotOptions(new PlotOptions
////    {
////        Pie = new PlotOptionsPie
////        {
////            AllowPointSelect = true,
////            Cursor = Cursors.Pointer,
////            DataLabels = new PlotOptionsPieDataLabels
////            {
////                Color = ColorTranslator.FromHtml("#000000"),
////                ConnectorColor = ColorTranslator.FromHtml("#000000"),
////                Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }"
////            }
////        }
////    })
////    .SetSeries(new Series
////    {
////        Type = ChartTypes.Pie,
////        Name = "Browser share",
////        Data = new Data(new object[]
////   {
////       new DotNet.Highcharts.Options.Point
////       {
////            Name = "Responding",
////            Y = 40,									
////            Sliced = true,
////            Selected = true,
////            Color = Color.Gray,                                    
////       },

////       new DotNet.Highcharts.Options.Point
////                          {
////            Name = "Not Responding" , 									
////            Y = 60,
////            Color = Color.Black,                                                        
////            Events = new PointEvents {Click = "PieClickEvent"}
////       }
////           })

////    });
//// .SetXAxis(new XAxis
////{
////    Categories = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
////})
////.SetSeries(new Series
////{
////    Data = new Data(new object[] { 29.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4 })
////});
