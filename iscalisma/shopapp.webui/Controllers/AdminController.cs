using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shopapp.businness.Abstract;
using shopapp.entity;
using shopapp.webui.Extensions;
using shopapp.webui.Identity;
using shopapp.webui.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace shopapp.webui.Controllers
{
    // [Authorize] ile artık admincontroller'a biz ulaşmak istediğimizde mutlaka yetkilendirmiş bir kullanıcı olması gerekiyor yani mutlaka uygulamaya login olmuş bir kullanıcı olması gerekiyor
    //sadikturan, efeturan => admin
    //adabilgi => customer
    //kulalnıcıları Admin rolüne atayabililirim ve admin ile olan işlemleri sadece Admin rolü olanlar yapabilsin diyebilirim
    [Authorize(Roles="admin")]
    public class AdminController:Controller
    {
        //inject
        //productsları VE CATEGORYLERİ service üzerinden alıcaz dolayısıyle inject işlemi gerekiyor
        private IProductService _productService;
        private ICategoryService _categoryService;
        //user inject için
        private UserManager<User> _userManager;
        //role inject için
        private RoleManager<IdentityRole> _roleManager;
        public AdminController(IProductService productService, ICategoryService categoryService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        //productları veritabanından sayfaya alalım
        public IActionResult ProductList()
        {
            return View(new ProductListViewModel()
            {
                //inject işleminden sonra artık herhangi bir bağımlılığımız olmadan gelip burda _productservice üzerinden getall metotunu çalıştırabiliyoruz
                Products = _productService.GetAll()
            });
        }
        //categoryleri veritabanından sayfaya alalım
        public IActionResult CategoryList()
        {
            return View(new CategoryListViewModel()
            {
                //inject işleminden sonra artık herhangi bir bağımlılığımız olmadan gelip burda _productservice üzerinden getall metotunu çalıştırabiliyoruz
                Categories = _categoryService.GetAll()
            });
        }
        //product ürün ekleme sayfası için
        //HttpGet'in görevi bize ilgili sayfayı view'i getirmek
        [HttpGet]
        public IActionResult ProductCreate()
        {
            return View();
        }
        //ve ben artık formu doldurdum formun içerisindeki bilgileri doldurup submit butonuna tıkaldım ve tıkladığım anda HttpPost edilmiş olacak verilerimizi post tipindeki form ile göndericez formdan bir bilgi gelecek olan bilgileri productmodel olarak alabilriiz
        [HttpPost]
        public IActionResult ProductCreate(ProductModel model)
        {
            //validation işmeleri yapalım eğer isvalid ise product model içerisine gönderdiğimiz bütün alanlar bizim istediğimiz kurallara uymuş demektir
            if (ModelState.IsValid)
            {
                //bize gelecek olan model.name gibi bilgileri yeni bir product olarak tanımlayalım entity altında
                var entity = new Product()
                {
                    Name = model.Name,
                    Url = model.Url,
                    Price = model.Price,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl
                };
                //oluşan entity'i database'E ekleriz
                //bu busnines validationu diğer return ile karıştırma o modeldi
                if (_productService.Create(entity))
                {
                    //Bir sorun yoksa ekeleme işlemini yapalım
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "kayıt eklendi",
                        Message = "kayıt eklendi",
                        AletyType = "success"
                    });
                    return RedirectToAction("ProductList");
                }
                //Bir problem varsa
                TempData.Put("message", new AlertMessage()
                {
                    Title = "hata",
                    Message = _productService.ErrorMessage,
                    AletyType = "danger"
                });
                return View(model);
            }
            //eğer validation kurallarına uygun değilse
            //bu model validationu
            return View(model);  
        }

        //CATEGORYLER İÇİN EKLEME CATEGORY METOTU
        //ürün ekleme sayfası için
        //HttpGet'in görevi bize ilgili sayfayı view'i getirmek
        [HttpGet]
        public IActionResult CategoryCreate()
        {
            return View();
        }
        //ve ben artık formu doldurdum formun içerisindeki bilgileri doldurup submit butonuna tıkaldım ve tıkladığım anda HttpPost edilmiş olacak verilerimizi post tipindeki form ile göndericez formdan bir bilgi gelecek olan bilgileri productmodel olarak alabilriiz
        [HttpPost]
        public IActionResult CategoryCreate(CategoryModel model)
        {
            //validation işmeleri yapalım eğer isvalid ise product model içerisine gönderdiğimiz bütün alanlar bizim istediğimiz kurallara uymuş demektir
            if (ModelState.IsValid)
            {
            //bize gelecek olan model.name gibi bilgileri yeni bir product olarak tanımlayalım entity altında
            var entity = new Category()
            {
                Name = model.Name,
                Url = model.Url
            };
            //oluşan entity'i database'E ekleriz
            _categoryService.Create(entity);
           //işlem bitince ProductList action metotu gösterilsin
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Kayıt eklendi.",
                    Message = $"{entity.Name} isimli category eklendi.",
                    AletyType = "success"
                });
            //Bütün cihazların anladığı jason tipinde bir veri
            //{"Massage: "samsung isimli ürün eklendi.", "AlertType: "success"}
            //hata mesajını Newtonsoft.Json paketini kurarak json bilgiye dönüştürmemiz lazım serilize etmemiz lazım yoksa hata alırız diserilize etme işleminide layout içinde yapıcaz
            return RedirectToAction("CategoryList");
            }
            //validation kurallarına uyulmadığı zaman
            return View(model);
        }



        //PRODUCT İÇİN EDİT KISMINI YAPALIM
        [HttpGet]
        public IActionResult ProductEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _productService.GetByIdWithCategories((int)id);
            if(entity == null)
            {
                return NotFound();
            }
            var model = new ProductModel()
            {
                ProductId = entity.ProductId,
                Name = entity.Name,
                Url = entity.Url,
                Price = entity.Price,
                ImageUrl = entity.ImageUrl,
                Description = entity.Description,
                IsApproved = entity.IsApproved,
                IsHome = entity.IsHome,
                SelectedCategories = entity.ProductCategories.Select(i=> i.Category).ToList()
            };
            ViewBag.Categories = _categoryService.GetAll();
          return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductModel model,int[] categoryIds,IFormFile file)
        {
            //validation işmeleri yapalım eğer isvalid ise product model içerisine gönderdiğimiz bütün alanlar bizim istediğimiz kurallara uymuş demektir
            if (ModelState.IsValid)
            {
            var entity = _productService.GetById(model.ProductId);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Name = model.Name;
            entity.Price = model.Price;
            entity.Url = model.Url;
            entity.Description = model.Description;
            entity.IsHome = model.IsHome;
            entity.IsApproved = model.IsApproved;

                //file upload için
                if (file != null)
                {
                    //resim nereye kaydedilecek
                    var extention = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    //veritabanına resim isminin kaydedilmesi olayı
                    entity.ImageUrl = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                //bu busnines validationu diğer return ile karıştırma o modeldi
                if (_productService.Update(entity, categoryIds))
                {
                    //Bir sorun yoksa ekeleme işlemini yapalım
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "kayıt güncellendi",
                        Message = "kayıt güncellendi",
                        AletyType = "success"
                    });
                    return RedirectToAction("ProductList");
                }
                //Bir problem varsa
                TempData.Put("message", new AlertMessage()
                {
                    Title = "hata",
                    Message = _productService.ErrorMessage,
                    AletyType = "danger"
                });
            }
            //validation kurallarına uymadığı taktirde
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }

        //Category İÇİN EDİT KISMINI YAPALIM
        [HttpGet]
        public IActionResult CategoryEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _categoryService.GetByIdWidthProducts((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            var model = new CategoryModel()
            {
                CategoryId = entity.CategoryId,
                Name = entity.Name,
                Url = entity.Url,
                Products = entity.ProductCategories.Select(p=> p.Product).ToList()

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult CategoryEdit(CategoryModel model)
        {
            //validation işmeleri yapalım eğer isvalid ise product model içerisine gönderdiğimiz bütün alanlar bizim istediğimiz kurallara uymuş demektir
            if (ModelState.IsValid) { 
            var entity = _categoryService.GetById(model.CategoryId);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Name = model.Name;
            entity.Url = model.Url;

            _categoryService.Update(entity);
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli category güncellendi.",
                AletyType = "success"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("CategoryList");
            }
            //validation kurallarına uyulmadığı zaman
            return View(model);
        }


        //PRODUCT SİLME İŞLEMİ İÇİN
        public IActionResult DeleteProduct(int productId)
        {
            var entity = _productService.GetById(productId);
            if (entity != null)
            {
                _productService.Delete(entity);
            }
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli ürün silindi.",
                AletyType = "danger"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("ProductList");
        }

        //CATEGORY SİLME İŞLEMİ İÇİN
        public IActionResult DeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);
            if (entity != null)
            {
                _categoryService.Delete(entity);
            }
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} isimli category silindi.",
                AletyType = "danger"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("CategoryList");
        }

        //veritabanından değilde categoryden ürün silmek
        [HttpPost]
        public IActionResult DeleteFromCategory(int productId, int categoryId)
        {
            _categoryService.DeleteFromCategory(productId, categoryId);
            return Redirect("/admin/categories/" + categoryId);
        }

        //role için edit action metotu
        public async Task<IActionResult> RoleEdit(string id)
        {
            //Bize bir rol edit yapacak
            var role = await _roleManager.FindByIdAsync(id);
            var members = new List<User>();
            var nonmembers = new List<User>();

            foreach (var user in _userManager.Users)
            {
                //burda veritabanındaki tüm üyeleri geziyoruz ve rolü var mı yok mu diye soruyoruz rolü varsa var members içine atıcaz eğer rolü yoksa var nonmembers içine atıcaz 
                var list = await _userManager.IsInRoleAsync(user, role.Name)?members:nonmembers;
                list.Add(user);
            }
            //almış olduğumuz bilgilerle model oluşturalım
            var model = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[] {})
                {
                    //ilgili role eklenecek olan userlaraı gezelim
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        //veritabanında bu kayıt varsa atama işlemini yaparız
                        var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
                //rolden silinecek olan kişileri seçicez
                foreach (var userId in model.IdsToDelete ?? new string[] {})
                {
                    //ilgili role eklenecek olan userlaraı gezelim
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        //veritabanında bu kayıt varsa atama işlemini yaparız
                        var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
            }
            return Redirect("/admin/role/" + model.RoleId);
        }
        //role için list action metotu
        //[AllowAnonymous] ekleyerek yetkilendirme işlemlerine bu actionu dahil etmiyoruz veya böyle actionlara farklı yetkilendirmeler verebiliriz tek tek
        [AllowAnonymous]
        public IActionResult RoleList()
        {
            //Bize bir rol listesi getirecek
            return View(_roleManager.Roles);
        }
        public IActionResult RoleCreate()
        {
            //Bize bir rol eklemesi yapacak
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel model)
        {
            //Bize bir rol eklemesi yapacak
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        //acction metotu kullanıcı detay sayfası için user listesini getirecek
        public IActionResult UserList()
        {
            return View(_userManager.Users);
        }
        //acction metotu kullanıcı detay sayfası için user edit için
        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var selectedRoles = await _userManager.GetRolesAsync(user);
                var roles = _roleManager.Roles.Select(i => i.Name);

                ViewBag.Roles = roles;
                return View(new UserDetailsModel() { 
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    SelectedRoles = selectedRoles
                });
            }
            return Redirect("~/admin/user/list");
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserDetailsModel model, string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.EmailConfirmed = model.EmailConfirmed;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        selectedRoles = selectedRoles ?? new string[] {};
                        await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles).ToArray<string>());

                        return Redirect("/admin/user/list");
                    }
                }
                return Redirect("/admin/user/list");
            }
            return View(model);
        }
}
}

