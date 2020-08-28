using Syncfusion.EJ.Export;
using Syncfusion.JavaScript.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exporting_EJ2component_using_EJ1_export_libraries.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.DataSource = GetData();
            return View();
        }

        public class GanttData
        {
            public int taskID { get; set; }
            public string taskName { get; set; }
            public string startDate { get; set; }
            public DateTime endDate { get; set; }
            public int duration { get; set; }
            public int progress { get; set; }
            public List<GanttData> subtasks { get; set; }
            public string predecessor { get; set; }
        }
        public static List<GanttData> GetData()
        {
            List<GanttData> list = new List<GanttData>();
            list.Add(new GanttData()
            {
                taskID = 1,
                taskName = "Parent Task 1",
                startDate = "02/27/2017",
                duration = 5,
                progress = 40,
                subtasks = (new List<GanttData>()
                    {
                        new GanttData()
                        {
                            taskID = 2,
                            taskName = "Child Task 1",
                            startDate = "02/27/2017",
                            duration = 5,
                            progress = 40
                        },
                        new GanttData()
                        {
                            taskID = 3,
                            taskName = "Child Task 2",
                            startDate = "02/27/2017",
                            duration = 5,
                            progress = 40,
                            predecessor = "2"
                        },
                        new GanttData()
                        {
                            taskID = 4,
                            taskName = "Child Task 3",
                            startDate = "02/27/2017",
                            duration = 5,
                            progress = 40,
                            predecessor = "3SS"
                        }
                    })
            });
            list.Add(new GanttData()
            {
                taskID = 5,
                taskName = "Parent Task 2",
                startDate = "02/27/2017",
                duration = 5,
                progress = 40,
                subtasks = (new List<GanttData>()
                    {
                        new GanttData()
                        {
                            taskID = 6,
                            taskName = "Child Task 1",
                            startDate = "02/27/2017",
                            duration = 5,
                            progress = 40
                        },
                        new GanttData()
                        {
                            taskID = 7,
                            taskName = "Child Task 2",
                            startDate = "02/27/2017",
                            duration = 5,
                            progress = 40,
                            predecessor = "6"
                        },
                        new GanttData()
                        {
                            taskID = 8,
                            taskName = "Child Task 3",
                            startDate = "02/27/2017",
                            duration = 7,
                            progress = 40,
                            predecessor = "7SS"
                        }
                    })
            });
            return list;
        }
        public void PdfExport()
        {
            GanttProperties gantt = getGanttProperties();
            PdfExport exp = new PdfExport();
            GanttPdfExportSettings settings = new GanttPdfExportSettings();
            settings.EnableFooter = true;
            settings.ProjectName = "Project Tracker";
            settings.IsFitToWidth = true;
            settings.Theme = GanttExportTheme.FlatLime;
            exp.Export(gantt, (IEnumerable)gantt.DataSource, settings, "Gantt");
        }
        private GanttProperties getGanttProperties()
        {
            GanttProperties gantt = new GanttProperties();
            gantt.TaskIdMapping = "taskID";
            gantt.TaskNameMapping = "taskName";
            gantt.StartDateMapping = "startDate";
            gantt.EndDateMapping = "endDate";
            gantt.ProgressMapping = "progress";
            gantt.DurationMapping = "duration";
            gantt.ChildMapping = "subtasks";
            gantt.PredecessorMapping = "predecessor";
            gantt.DataSource = GetData();
            List<GanttColumn> colList = new List<GanttColumn>();
            colList.Add(new GanttColumn() { Field = "taskID", MappingName = "taskID", HeaderText = "ID", Width = 70 });
            colList.Add(new GanttColumn() { Field = "taskName", MappingName = "taskName", HeaderText = "Task Name", Width = 100 });
            colList.Add(new GanttColumn() { Field = "startDate", MappingName = "startDate", HeaderText = "Start Date", Width = 100 });
            colList.Add(new GanttColumn() { Field = "endDate", MappingName = "endDate", HeaderText = "End Date", Width = 100 });
            colList.Add(new GanttColumn() { Field = "duration", MappingName = "duration", HeaderText = "duration", Width = 70 });
            colList.Add(new GanttColumn() { Field = "progress", MappingName = "progress", HeaderText = "progress", Width = 70 });
            gantt.Columns = colList;
            gantt.ScheduleStartDate = "02/26/2017";
            gantt.ScheduleEndDate = "03/18/2017";
            return gantt;
        }
    }
}