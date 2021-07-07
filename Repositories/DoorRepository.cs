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
    /// 門鎖
    /// </summary>
    public class DoorRepository : IDoorRepository {

        private DatabaseContext DatabaseContext;
        private readonly IMapper Mapper;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_DatabaseContext">資料庫上下文</param>
        /// <param name="_Mapper">模型映射</param>
        public DoorRepository(DatabaseContext _DatabaseContext, IMapper _Mapper) {
            DatabaseContext = _DatabaseContext;
            Mapper = _Mapper;
        }


        #region "讀取"

        /// <summary>
        /// 取得門鎖
        /// </summary>
        /// <param name="_Seq">流水編號</param>
        /// <returns>DoorModel</returns>
        public async Task<DoorModel> Get(int _Seq = 0) {
            var Model = await DatabaseContext.Door
                                             .AsQueryable()
                                             .Where(x => x.Seq == _Seq)
                                             .FirstOrDefaultAsync();

            if (Model == null) {
                Model = new DoorModel();
            }

            return Model;
        }


        /// <summary>
        /// 取得門鎖清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>Tuple</returns>
        public async Task<(List<DoorViewModel> List, int Count)> GetList(DoorListEntry _Entry) {
            int PageNow = _Entry.PageNow;
            int PageShow = _Entry.PageShow;
            string Keyword = _Entry.Keyword;
            int FloorLevel = _Entry.FloorLevel;

            var Query = DatabaseContext.Door.AsQueryable();

            // 關鍵字
            if (!string.IsNullOrEmpty(Keyword)) {
                Query = Query.Where(x => x.Name.Contains(Keyword));
            }

            // 樓層層級
            if (FloorLevel != 0) {
                Query = Query.Where(x => x.FloorLevel == FloorLevel);
            }

            int Count = await Query.CountAsync();

            var List = await Query.OrderBy(x => x.Seq)
                                  .Skip((PageNow - 1) * PageShow)
                                  .Take(PageShow)
                                  .ToListAsync();

            // 模型映射
            var ListVM = Mapper.Map<List<DoorModel>, List<DoorViewModel>>(List);

            ListVM.ForEach(x => {
                x.BatteryTimeStr = x.BatteryTime.ToString("yyyy-MM-dd HH:mm:ss");
                x.ActionTimeStr = x.ActionTime.ToString("yyyy-MM-dd HH:mm:ss");
                x.StatusStr = x.Status.ToEnumDescription();
            });

            return (ListVM, Count);
        }


        /// <summary>
        /// 取得門鎖拖曳清單
        /// </summary>
        /// <param name="_FloorLevel">樓層層級</param>
        /// <returns>List</returns>
        public async Task<List<DoorDragViewModel>> GetDragList(int _FloorLevel = 0) {
            var List = await DatabaseContext.Door.AsQueryable()
                                                 .Where(x => x.FloorLevel == _FloorLevel)
                                                 .Select(x => new DoorDragViewModel() {
                                                     ID = x.ID,
                                                     PositionX = x.PositionX,
                                                     PositionY = x.PositionY
                                                 })
                                                 .ToListAsync();

            return List;
        }


        /// <summary>
        /// 取得門鎖數量
        /// </summary>
        /// <returns>int</returns>
        public async Task<int> GetCount() {
            return await DatabaseContext.Door.AsQueryable().CountAsync();
        }


        /// <summary>
        /// 取得門鎖指標
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>int</returns>
        public async Task<int> GetCursor(DoorCursorEntry _Entry) {
            int Seq = 0;
            DoorModel Model = new DoorModel();

            var Query = DatabaseContext.Door.AsQueryable();

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
        /// 新增門鎖
        /// </summary>
        /// <param name="_Model">模型</param>
        /// <returns>Task</returns>
        public async Task Set(DoorModel _Model) {
            DatabaseContext.Door.Add(_Model);

            await DatabaseContext.SaveChangesAsync();
        }


        /// <summary>
        /// 新增門鎖
        /// </summary>
        /// <param name="_List">清單</param>
        /// <returns>Task</returns>
        public async Task Set(List<DoorModel> _List) {
            await DatabaseContext.Door.AddRangeAsync(_List);

            await DatabaseContext.SaveChangesAsync();
        }

        #endregion




        #region "修改"

        /// <summary>
        /// 修改門鎖
        /// </summary>
        /// <remarks>
        /// 電量必須另外處理
        /// </remarks>
        /// <param name="_Model">模型</param>
        /// <returns>Task</returns>
        public async Task Update(DoorModel _Model) {
            var Temp = await DatabaseContext.Door.SingleAsync(x => x.ID == _Model.ID);

            if (Temp != null) {
                Temp.Name = _Model.Name;
                Temp.FloorLevel = _Model.FloorLevel;
                Temp.Note = _Model.Note;

                // 狀態
                if (_Model.Status != SCIENER_LOCK_STATE.UNKNOW) {
                    Temp.Status = _Model.Status;
                }

                Temp.IsRemote = _Model.IsRemote;

                await DatabaseContext.SaveChangesAsync();
            }
        }


        /// <summary>
        /// 修改門鎖
        /// </summary>
        /// <param name="_Model">模型</param>
        /// <returns>Task</returns>
        public async Task Update(DoorUpdateEntry _Model) {
            var Temp = await DatabaseContext.Door.SingleAsync(x => x.ID == _Model.ID);

            if (Temp != null) {
                Temp.Name = _Model.Name;
                Temp.Note = _Model.Note;
                Temp.Battery = _Model.Battery;
                Temp.BatteryTime = _Model.BatteryTime;

                await DatabaseContext.SaveChangesAsync();
            }
        }


        /// <summary>
        /// 修改門鎖
        /// </summary>
        /// <param name="_List">清單</param>
        /// <returns>Task</returns>
        public async Task Update(List<DoorUpdateEntry> _List) {
            await _List.ForEachAsync(async Model => {
                // 修改門鎖
                await Update(Model);
            });
        }


        /// <summary>
        /// 拖曳門鎖
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>Task</returns>
        public async Task Drag(DoorDragEntry _Entry) {
            var Temp = await DatabaseContext.Door.SingleAsync(x => x.ID == _Entry.ID);

            if (Temp != null) {
                Temp.PositionX = _Entry.PositionX;
                Temp.PositionY = _Entry.PositionY;

                await DatabaseContext.SaveChangesAsync();
            }
        }

        #endregion




        #region "刪除"

        /// <summary>
        /// 刪除門鎖
        /// </summary>
        /// <param name="_ID">門鎖編號</param>
        /// <returns>Task</returns>
        public async Task Delete(int _ID = 0) {
            var Query = DatabaseContext.Door
                                       .AsQueryable()
                                       .Where(x => x.ID == _ID);

            DatabaseContext.Door.RemoveRange(Query);

            await DatabaseContext.SaveChangesAsync();
        }


        /// <summary>
        /// 刪除門鎖
        /// </summary>
        /// <param name="_List">門鎖編號清單</param>
        /// <returns>Task</returns>
        public async Task Delete(List<int> _List) {
            var Query = DatabaseContext.Door
                                       .AsQueryable()
                                       .Where(x => _List.Contains(x.ID));

            DatabaseContext.Door.RemoveRange(Query);

            await DatabaseContext.SaveChangesAsync();
        }

        #endregion




        #region "其它"

        /// <summary>
        /// 檢查門鎖編號
        /// </summary>
        /// <param name="_ID">門鎖編號</param>
        /// <returns>bool</returns>
        public async Task<bool> CheckID(int _ID = 0) {
            bool Flag = false;

            var Model = await DatabaseContext.Door
                                             .AsQueryable()
                                             .AsNoTracking()
                                             .Where(x => x.ID == _ID)
                                             .FirstOrDefaultAsync();

            if (Model != null) {
                Flag = true;
            }

            return Flag;
        }

        #endregion

    }
}