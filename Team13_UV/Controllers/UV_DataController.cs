using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Team13_UV.Models;

namespace Team13_UV.Controllers
{
    public class UV_DataController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: UV_Data
        public ActionResult Index()
        {
            return View(db.UV_Data.ToList());
        }

        // GET: UV_Data/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UV_Data uV_Data = db.UV_Data.Find(id);
            if (uV_Data == null)
            {
                return HttpNotFound();
            }
            return View(uV_Data);
        }

        // GET: UV_Data/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UV_Data/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,UV_Index")] UV_Data uV_Data)
        {
            if (ModelState.IsValid)
            {
                db.UV_Data.Add(uV_Data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uV_Data);
        }

        // GET: UV_Data/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UV_Data uV_Data = db.UV_Data.Find(id);
            if (uV_Data == null)
            {
                return HttpNotFound();
            }
            return View(uV_Data);
        }

        // POST: UV_Data/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,UV_Index")] UV_Data uV_Data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uV_Data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uV_Data);
        }

        // GET: UV_Data/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UV_Data uV_Data = db.UV_Data.Find(id);
            if (uV_Data == null)
            {
                return HttpNotFound();
            }
            return View(uV_Data);
        }

        // POST: UV_Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UV_Data uV_Data = db.UV_Data.Find(id);
            db.UV_Data.Remove(uV_Data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
