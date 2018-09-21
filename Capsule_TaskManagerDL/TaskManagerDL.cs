using Capsule_TaskManagerDL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capsule_TaskManagerDL
{
    public class TaskManagerDL
    {

        #region GetParentTask
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Get_Parent_Task_Result> GetParentTask()
        {
            using (TaskManagerEntities db = new TaskManagerEntities())
            {
                var VParentTask = db.Get_Parent_Task().ToList();
                return VParentTask;
            }

        }
        #endregion 
        
        #region GetTaskDetails
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public IEnumerable<Get_Task_Details_Result> GetTaskDetails()
        {
            using (TaskManagerEntities db = new TaskManagerEntities())
            {
                var VTaskDetails = db.Get_Task_Details().ToList();
                return VTaskDetails;
            }

        }
        #endregion

        #region InsertTaskDetails
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objGET_TASK_DETAILS_Result"></param>
        /// <returns></returns>

        public string InsertTaskDetails(Get_Task_Details_Result objGET_TASK_DETAILS_Result)
        {
            using (TaskManagerEntities db = new TaskManagerEntities())
            {
                objGET_TASK_DETAILS_Result.Task_ID = objGET_TASK_DETAILS_Result.Task_ID == null ? "0" : objGET_TASK_DETAILS_Result.Task_ID;
                if (objGET_TASK_DETAILS_Result.Task_ID == null || objGET_TASK_DETAILS_Result.Task_ID == "")
                    objGET_TASK_DETAILS_Result.Task_ID = "0";
                if (objGET_TASK_DETAILS_Result.Parent_ID == null || objGET_TASK_DETAILS_Result.Parent_ID == "")
                    objGET_TASK_DETAILS_Result.Parent_ID = "0";

                var vInsertTaskDetails = db.INSERT_TASK_DETAILS(Convert.ToInt32(objGET_TASK_DETAILS_Result.Task_ID), Convert.ToInt32(objGET_TASK_DETAILS_Result.Parent_ID), objGET_TASK_DETAILS_Result.Task, objGET_TASK_DETAILS_Result.Start_Date, objGET_TASK_DETAILS_Result.End_Date, objGET_TASK_DETAILS_Result.Priority);

                db.SaveChanges();
                return Convert.ToString(vInsertTaskDetails);
            }

        }
        #endregion

        #region UpdateEndTask
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objGET_TASK_DETAILS_Result"></param>
        /// <returns></returns>

        public string UpdateEndTask(Get_Task_Details_Result objGET_TASK_DETAILS_Result)
        {
            using (TaskManagerEntities db = new TaskManagerEntities())
            {
                var vUpdateEndTask = db.UPDATE_END_TASK(Convert.ToInt32(objGET_TASK_DETAILS_Result.Task_ID), objGET_TASK_DETAILS_Result.End_Date);
                db.SaveChanges();
                return Convert.ToString(vUpdateEndTask);
            }

        }
        #endregion 
    }
}
