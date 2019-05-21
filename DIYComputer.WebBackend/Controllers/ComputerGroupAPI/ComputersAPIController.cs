﻿using AutoMapper;
using DIYComputer.DtoModel.SysDto;
using DIYComputer.Entity.DBContext;
using DIYComputer.Entity.SysEntity;
using DIYComputer.Util;
using DIYComputer.Util.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DIYComputer.WebBackend.Controllers.ComputerGroupAPI
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComputersAPIController:Controller
    {

        private readonly EFDBContext _context;

        private readonly IMapper _mapper;

        public ComputersAPIController(EFDBContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [Route("GetComputerById")]
        public JsonResult GetId(int id = -1)
        {
            var result = _context.Computers.Where(o => o.Id == id).DefaultIfEmpty();
            return Json(ResultToJson.GetJsonResult(result));

        }

        [HttpGet]
        [Route("GetAllComputerOnlyId")]
        public JsonResult GetToListOnlyId(string planname = "", string username = "", int userid = -1, int valuesum1 = 0, int valuesum2 = 9999999, int indexPage = 1, int size = 30)
        {

            string s = "";
            var resmodel = _context.Computers.Where(


                  o => (o.PlanName.IndexOf(planname) >= 0 &&
                       (o.ValueSum >= valuesum1 && o.ValueSum <= valuesum2))

                ).Skip(((indexPage - 1) > 0 ? indexPage - 1 : 0) * (size > 0 ? size : 0)).ToList();
            if (username.Length > 0)
            {
                foreach (var item in resmodel)
                {
                    item.User = _context.Users.Where(o => o.Id == item.UserID).FirstOrDefault();
                }
                resmodel = resmodel.Where(o => o.User.Account.Contains(username)).ToList();
            }
            if (userid > 0)
            {
                resmodel.Where(o => o.UserID == userid).ToList();
            }
            List<ComputerDto >lc= _mapper.Map<List<ComputerDto>>(resmodel);
            foreach (var item in lc)
            {
                var User = _context.Users.FirstOrDefault(o => o.Id == item.UserID);

                item.UserDisplay = new  UserDisplayModel()
                {
                    Account = User.Account,
                    Id = User.Id,
                    Mail = User.Mail,
                    Tell = User.Tell,
                    Name = User.Name,
                };

              

            }
            PageSplitModel<ComputerDto> result = new PageSplitModel<ComputerDto>(lc, indexPage, size, resmodel.Count);

            return Json(ResultToJson.GetJsonResult(result));

        }
        [HttpGet]
        [Route("GetComputerPlanClass")]
        public JsonResult GetComputerPlanClass()
        {


            List<string> retmo = new List<string>()
            {
              "经济实惠 ",
              "家用办公 ",
              "普通游戏 ",
              "大型3D游戏",
              "游戏多开 ",
              "游戏工作室",
              "网吧 ",
              "客厅HTPC ",
              "老年电脑 ",
              "电视功能 ",
              "平面设计 ",
              "3D视频后期",
              "web服务器 ",
              "图形工作站",
              "办公服务器",
              "IDC服务器 ",
              "音频 ",
              "多屏显示 ",
              "顶级发烧 ",
              "极品定制 ",
              "玩家国度 "
            };


            return Json(ResultToJson.GetJsonResult(retmo));
        }
        [HttpGet]
        [Route("GetAllComputer")]
        public JsonResult GetToList(string planname="",string username = "",int userid=-1,int valuesum1 =0,int valuesum2 = 9999999, int indexPage = 1, int size = 30)
        {

            string s = "";
            var resmodel = _context.Computers.Where(

                  o => (o.PlanName.IndexOf(planname)>=0 &&
                       (o.ValueSum >= valuesum1 && o.ValueSum <= valuesum2))

                ).Skip(((indexPage-1) > 0 ? indexPage-1 : 0) *( size > 0 ? size : 0))
                            .Include(o => o.Case)
                            .Include(o => o.CDROM)
                            .Include(o => o.CPU)
                            .Include(o => o.CPUHS)
                            .Include(o => o.Display)
                            .Include(o => o.Graphyic)
                            .Include(o => o.HardDisk)
                            .Include(o => o.Mainboard)
                            .Include(o => o.NetWork)
                            .Include(o => o.Power)
                            .Include(o => o.ROM)
                            .Include(o => o.SSD)
                            .ToList();
               if(username.Length>0)
            {
                foreach (var item in resmodel)
                {
                    item.User = _context.Users.Where(o => o.Id == item.UserID).FirstOrDefault();
                }
                resmodel = resmodel.Where(o => o.User.Account.Contains(username)).ToList();
            }
            if (userid > 0)
            { 
                resmodel.Where(o => o.UserID == userid).ToList();
            }
            List<ComputerDto> lc = _mapper.Map<List<ComputerDto>>(resmodel);
            foreach (var item in lc)
            {
               var   User = _context.Users.FirstOrDefault(o => o.Id == item.UserID);

                item.UserDisplay = new UserDisplayModel()
                {
                    Account = User.Account,
                    Id = User.Id,
                    Mail = User.Mail,
                    Tell = User.Tell,
                    Name = User.Name,
                };

              

            }
            PageSplitModel<ComputerDto> result = new PageSplitModel<ComputerDto>(lc, indexPage, size, resmodel.Count);

            return Json(ResultToJson.GetJsonResult(result));

        }
    }
}
