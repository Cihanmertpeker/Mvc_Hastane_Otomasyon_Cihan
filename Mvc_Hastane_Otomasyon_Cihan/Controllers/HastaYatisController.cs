using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Hastane_Otomasyon_Cihan.Models;

namespace Mvc_Hastane_Otomasyon_Cihan.Controllers
{
    public class HastaYatisController : Controller
    {
        HastaneDbEntities db = new HastaneDbEntities();
        // GET: HastaYatis
        public ActionResult Hasta_Yatis()
        {
            var hastayatisListem = db.Hasta_Yatis.ToList();
            return View(hastayatisListem);
        }
        public ActionResult yeniKayit()
        {
            ViewBag.Hasta_no = new SelectList(db.Hastalar, "Hasta_no", "Hasta_no");
            ViewBag.Doktor_no = new SelectList(db.Doktorlar, "Doktor_no", "Doktor_no");
            ViewBag.Dept_no = new SelectList(db.Departmanlar, "Dept_no", "Dept_no");

            return View();
        }
        [HttpPost]
        public ActionResult yeniKayit(Hasta_Yatis yeni_Hasta_Yatis)
        {
            ViewBag.Hasta_no = new SelectList(db.Hastalar, "Hasta_no", "Hasta_no");
            ViewBag.Doktor_no = new SelectList(db.Doktorlar, "Doktor_no", "Doktor_no");
            ViewBag.Dept_no = new SelectList(db.Departmanlar, "Dept_no", "Dept_no");
            try
            {            
            if (ModelState.IsValid)
            {
                db.Hasta_Yatis.Add(yeni_Hasta_Yatis);
                db.SaveChanges();
            }

            ViewBag.sonuc = "Kayıt Başarılı.";
            }
            catch (Exception)
            {
                ViewBag.sonuc = "Girilen bilgileri kontrol ediniz. kayıtlı bilgiler tekrarlanamaz";
            }
            return View();            
        }
        public ActionResult hastayatis_sil(int id)
        {
            var silenecek_hastayatis = db.Hasta_Yatis.Find(id);
            db.Hasta_Yatis.Remove(silenecek_hastayatis);
            db.SaveChanges();

            return RedirectToAction("Hasta_Yatis");
            
        }
        public ActionResult hastayatis_guncelle(int id)
        {
            ViewBag.Hasta_no = new SelectList(db.Hastalar, "Hasta_no", "Hasta_no");
            ViewBag.Doktor_no = new SelectList(db.Doktorlar, "Doktor_no", "Doktor_no");
            ViewBag.Dept_no = new SelectList(db.Departmanlar, "Dept_no", "Dept_no");
            var hastayatis_no = db.Hasta_Yatis.Find(id);
            return View(hastayatis_no);            

        }
        [HttpPost]
        public ActionResult hastayatis_guncelle(Hasta_Yatis yeni_Hasta_Yatis)
        {

            ViewBag.Hasta_no = new SelectList(db.Hastalar, "Hasta_no", "Hasta_no");
            ViewBag.Doktor_no = new SelectList(db.Doktorlar, "Doktor_no", "Doktor_no");
            ViewBag.Dept_no = new SelectList(db.Departmanlar, "Dept_no", "Dept_no");
            try
            {
                if (ModelState.IsValid)
                {

                    db.Entry(yeni_Hasta_Yatis).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                ViewBag.sonuc = "Güncelleme Başarılı.";
            }
            catch (Exception)
            {
                ViewBag.sonuc = "Girilen bilgileri kontrol ediniz. kayıtlı bilgiler tekrarlanamaz";
            }
            ViewBag.Hasta_no = new SelectList(db.Hastalar, "Hasta_no", "Hasta_no");
            ViewBag.Doktor_no = new SelectList(db.Doktorlar, "Doktor_no", "Doktor_no");
            ViewBag.Dept_no = new SelectList(db.Departmanlar, "Dept_no", "Dept_no");
            return View(yeni_Hasta_Yatis);

        }
}
} 