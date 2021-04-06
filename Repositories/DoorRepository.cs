using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Surveillance.Interfaces;
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
        /// 取得門鎖清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>Tuple</returns>
        public async Task<(List<DoorViewModel> List, int Count)> GetList(DoorEntry _Entry) {
            int PageNow = _Entry.PageNow;
            int PageShow = _Entry.PageShow;
            string Keyword = _Entry.Keyword;
            int Floor = _Entry.Floor;

            var Query = DatabaseContext.Door.AsQueryable();

            // 關鍵字
            if (!string.IsNullOrEmpty(Keyword)) {
                Query = Query.Where(x => x.ID.Contains(Keyword) || x.Name.Contains(Keyword));
            }

            // 樓層
            if (Floor > 0) {
                Query = Query.Where(x => x.Floor == Floor);
            }

            int Count = await Query.CountAsync();

            var List = await Query.Skip((PageNow - 1) * PageShow)
                                  .Take(PageShow)
                                  .ToListAsync();

            // 模型映射
            var ListVM = Mapper.Map<List<DoorModel>, List<DoorViewModel>>(List);

            ListVM.ForEach(x => {
                x.StatusStr = x.StatusStr.ToString();   // TODO - 門鎖，狀態
                x.ActionTimeStr = x.ActionTime.ToString("yyyy-MM-dd HH:mm:ss");
            });

            return (ListVM, Count);
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

        #endregion




        #region "刪除"

        /// <summary>
        /// 刪除門鎖
        /// </summary>
        /// <param name="_ID">門鎖編號</param>
        /// <returns>Task</returns>
        public async Task Delete(string _ID = "") {
            var Query = DatabaseContext.Door
                                       .AsQueryable()
                                       .Where(x => x.ID == _ID);

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
        public async Task<bool> CheckID(string _ID = "") {
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