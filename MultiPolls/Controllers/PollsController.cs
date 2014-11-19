using System;
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

namespace MultiPolls.Controllers
{
    public class PollsController : Controller
    {
        private PollDBContext db = new PollDBContext();

        // GET: /Polls/
        public ActionResult Index()
        {
            return View(db.Polls.ToList());
        }

        // GET: /Polls/Details/5
        public ActionResult Details(int? id)
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

        // GET: /Polls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Polls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,CreationDate,EditDate,CreatorID,PollQuestion,OptionA,OptionB,OptionC,OptionD,OptionE,OptionF,OptionG,OptionH,OptionI,OptionJ")] Poll poll)
        {
            if (ModelState.IsValid)
            {
                poll.CreationDate = DateTime.Now;
                poll.EditDate = DateTime.Now;
                db.Polls.Add(poll);
                db.SaveChanges();
                return RedirectToAction("PrivatePolls");
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
        public ActionResult Edit([Bind(Include="ID,CreationDate,EditDate,CreatorID,PollQuestion,OptionA,OptionB,OptionC,OptionD,OptionE,OptionF,OptionG,OptionH,OptionI,OptionJ")] Poll poll)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poll).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PrivatePolls");
            }
            return View(poll);
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
            return RedirectToAction("/Polls/Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: /Polls/PublishedPolls
        public ActionResult PublishedPolls()
        {
            return View(db.Polls.ToList());
        }

        // GET: /Polls/Vote
        public ActionResult Vote(int? id)
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

        // POST: /Polls/Vote/4
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(int? id, string Option, [Bind(Include = "ID,CreationDate,EditDate,CreatorID,PollQuestion,OptionA,OptionB,OptionC,OptionD,OptionE,OptionF,OptionG,OptionH,OptionI,OptionJ")] Poll poll)
        {
            if (ModelState.IsValid)
            {
                //if 
                if (Option == "B")
                {
                    poll = db.Polls.Find(id);
                    poll.AnswerB = poll.AnswerB + 1;
                    db.SaveChanges();
                    return RedirectToAction("PollResults/" + id);
                }
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
                Name = "Test pie chart",
                Data = new Data(new object[]
                {
                    
                    
                    new object[] { poll.OptionA, poll.AnswerA },
                    new object[] { poll.OptionB, poll.AnswerB },
                    //new DotNet.Highcharts.Options.Point
                    //{
                    //    Name = "Chrome",
                    //    Y = 12.8,
                    //    Sliced = true,
                    //    Selected = true
                    //},
                    //new object[] { "Safari", 8.5 },
                    //new object[] { "Opera", 6.2 },
                    //new object[] { "Others", 0.7 }
                })
            });
            chart.SetTitle(new Title {Text = "MrWizards Chart"});
            
            
            //poll = db.Polls.Find(id);
            if (poll == null)
            {
                return HttpNotFound();
            }
            return View(chart);
        }
    }
}



//Maybe useful info
//-----------------------------//
//.SetTitle(new Title 
//{ 
//    Text = "MrWizard's Chart" 
//});

//.AddJavascripFunction("ChartClickEvent", @"$.get('signup/signup')")
//.SetCredits(new Credits { Enabled = false })
//.SetTitle(new Title { Text = "Sign ups" });

//chart.InitChart(new Chart
//    {
//        BorderWidth = 0,
//        BorderRadius = 15,
//        PlotBackgroundColor = null,
//        PlotShadow = false,
//        PlotBorderWidth = 0,
//        Events = new ChartEvents { Click = "@Navigate()" },
//        BackgroundColor = new BackColorOrGradient(new Gradient
//        {
//            LinearGradient = new[] { 0, 0, 0, 400 },
//            Stops = new object[,]
//           {
//               { 0, Color.FromArgb(255, 96, 96, 96) },
//               { 1, Color.FromArgb(255, 16, 16, 16) }
//           }
//        }),
//    })
//    .SetCredits(new Credits { Enabled = false })
//    .SetOptions(new GlobalOptions
//    {
//        Colors = new[]
//       {
//        ColorTranslator.FromHtml("#DDDF0D"),
//        ColorTranslator.FromHtml("#7798BF"),
//        ColorTranslator.FromHtml("#55BF3B"),
//        ColorTranslator.FromHtml("#DF5353"),
//        ColorTranslator.FromHtml("#DDDF0D"),
//        ColorTranslator.FromHtml("#aaeeee"),
//        ColorTranslator.FromHtml("#ff0066"),
//        ColorTranslator.FromHtml("#eeaaee")
//       }
//    })
//    .SetTitle(new Title { Text = "Devices Not Responding", Style = "color: '#FFF', font: '16px Lucida Grande, Lucida Sans Unicode, Verdana, Arial, Helvetica, sans-serif'" })
//    .SetTooltip(new Tooltip { Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }" })
//    .SetPlotOptions(new PlotOptions
//    {
//        Pie = new PlotOptionsPie
//        {
//            AllowPointSelect = true,
//            Cursor = Cursors.Pointer,
//            DataLabels = new PlotOptionsPieDataLabels
//            {
//                Color = ColorTranslator.FromHtml("#000000"),
//                ConnectorColor = ColorTranslator.FromHtml("#000000"),
//                Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }"
//            }
//        }
//    })
//    .SetSeries(new Series
//    {
//        Type = ChartTypes.Pie,
//        Name = "Browser share",
//        Data = new Data(new object[]
//   {
//       new DotNet.Highcharts.Options.Point
//       {
//            Name = "Responding",
//            Y = 40,									
//            Sliced = true,
//            Selected = true,
//            Color = Color.Gray,                                    
//       },

//       new DotNet.Highcharts.Options.Point
//                          {
//            Name = "Not Responding" , 									
//            Y = 60,
//            Color = Color.Black,                                                        
//            Events = new PointEvents {Click = "PieClickEvent"}
//       }
//           })

//    });
// .SetXAxis(new XAxis
//{
//    Categories = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
//})
//.SetSeries(new Series
//{
//    Data = new Data(new object[] { 29.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4 })
//});
