using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Surveillance.Enums;
using Surveillance.Interfaces;
using Surveillance.Library;
using Surveillance.Models;
using Surveillance.ViewModels;
using Surveillance.Schafold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Surveillance.Repositories {

    /// <summary>
    /// 樓層
    /// </summary>
    public class FloorRepository : IFloorRepository {

        private DatabaseContext DatabaseContext;
        private readonly IMapper Mapper;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_DatabaseContext">資料庫上下文</param>
        /// <param name="_Mapper">模型映射</param>
        public FloorRepository(DatabaseContext _DatabaseContext, IMapper _Mapper) {
            DatabaseContext = _DatabaseContext;
            Mapper = _Mapper;
        }


        #region "讀取"

        /// <summary>
        /// 取得樓層
        /// </summary>
        /// <param name="_Seq">流水編號</param>
        /// <returns>FloorModel</returns>
        public async Task<FloorModel> Get(int _Seq = 0) {
            var Model = await DatabaseContext.Floor
                                             .AsQueryable()
                                             .Where(x => x.Seq == _Seq)
                                             .FirstOrDefaultAsync();

            if (Model == null) {
                Model = new FloorModel();
            }

            return Model;
        }


        /// <summary>
        /// 取得樓層圖片
        /// </summary>
        /// <param name="_Seq">流水編號</param>
        /// <returns>ImageModel</returns>
        public async Task<ImageModel> GetImage(int _Seq = 0) {
            var Model = new ImageModel();

            var Temp = await DatabaseContext.Floor.AsQueryable()
                                                  .Where(x => x.Seq == _Seq)
                                                  .Select(x => new {
                                                      x.Image,
                                                      x.ImageType
                                                  })
                                                  .FirstOrDefaultAsync();

            if (Temp != null) {
                // 取得圖片尺寸
                var TupleSize = Tool.GetImageSize(Temp.Image);

                Model.Image = Temp?.Image;
                Model.ImageType = Temp?.ImageType;
                Model.Width = TupleSize.Width;
                Model.Height = TupleSize.Height;
            }

            return Model;
        }


        /// <summary>
        /// 取得樓層清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>Tuple</returns>
        public async Task<(List<FloorViewModel> List, int Count)> GetList(FloorEntry _Entry) {
            int PageNow = _Entry.PageNow;
            int PageShow = _Entry.PageShow;
            string Keyword = _Entry.Keyword;
            int Level = _Entry.Level;

            var Query = DatabaseContext.Floor.AsQueryable();

            // 關鍵字
            if (!string.IsNullOrEmpty(Keyword)) {
                Query = Query.Where(x => x.Name.Contains(Keyword));
            }

            // 層級
            if (Level != 0) {
                Query = Query.Where(x => x.Level == Level);
            }

            int Count = await Query.CountAsync();

            var List = await Query.OrderBy(x => x.Seq)
                                  .Skip((PageNow - 1) * PageShow)
                                  .Take(PageShow)
                                  .ToListAsync();

            // 模型映射
            var ListVM = Mapper.Map<List<FloorModel>, List<FloorViewModel>>(List);

            ListVM.ForEach(x => {
                // NOTHING
            });

            return (ListVM, Count);
        }


        /// <summary>
        /// 取得樓層數量
        /// </summary>
        /// <returns>int</returns>
        public async Task<int> GetCount() {
            return await DatabaseContext.Floor.AsQueryable().CountAsync();
        }


        /// <summary>
        /// 取得樓層指標
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>int</returns>
        public async Task<int> GetCursor(FloorCursorEntry _Entry) {
            int Seq = 0;
            FloorModel Model = new FloorModel();

            var Query = DatabaseContext.Floor.AsQueryable();

            if (_Entry.Direction) {
                Model = await Query.Where(x => x.Seq > _Entry.Seq)
                                   .OrderBy(x => x.Seq)
                                   .FirstOrDefaultAsync();
            } else {
                Model = await Query.Where(x => x.Seq < _Entry.Seq)
                                   .OrderByDescending(x => x.Seq)
                                   .FirstOrDefaultAsync();
            }

            if (Model != null) {
                Seq = Model.Seq;
            }

            return Seq;
        }

        #endregion




        #region "新增"

        /// <summary>
        /// 新增樓層
        /// </summary>
        /// <param name="_Model">模型</param>
        /// <returns>Task</returns>
        public async Task Set(FloorModel _Model) {
            DatabaseContext.Floor.Add(_Model);

            await DatabaseContext.SaveChangesAsync();
        }


        /// <summary>
        /// 新增樓層
        /// </summary>
        /// <param name="_List">清單</param>
        /// <returns>Task</returns>
        public async Task Set(List<FloorModel> _List) {
            await DatabaseContext.Floor.AddRangeAsync(_List);

            await DatabaseContext.SaveChangesAsync();
        }

        #endregion




        #region "修改"

        /// <summary>
        /// 修改樓層
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>Task</returns>
        public async Task Update(FloorUpdateEntry _Entry) {
            var Temp = await DatabaseContext.Floor.SingleAsync(x => x.Seq == _Entry.Seq);

            if (Temp != null) {
                Temp.Name = _Entry.Name;
                Temp.Level = _Entry.Level;

                await DatabaseContext.SaveChangesAsync();
            }
        }

        #endregion




        #region "刪除"

        /// <summary>
        /// 刪除樓層
        /// </summary>
        /// <param name="_Seq">流水編號</param>
        /// <returns>Task</returns>
        public async Task Delete(int _Seq = 0) {
            var Query = DatabaseContext.Floor
                                       .AsQueryable()
                                       .Where(x => x.Seq == _Seq);

            DatabaseContext.Floor.RemoveRange(Query);

            await DatabaseContext.SaveChangesAsync();
        }

        #endregion




        #region "其它"

        /// <summary>
        /// 檢查層級
        /// </summary>
        /// <param name="_Level">層級</param>
        /// <returns>bool</returns>
        public async Task<bool> CheckLevel(int _Level = 0) {
            bool Flag = false;

            var Model = await DatabaseContext.Floor
                                             .AsQueryable()
                                             .AsNoTracking()
                                             .Where(x => x.Level == _Level)
                                             .FirstOrDefaultAsync();

            if (Model != null) {
                Flag = true;
            }

            return Flag;
        }

        #endregion

    }
}