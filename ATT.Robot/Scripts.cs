﻿using ATT.Data;
using ATT.Data.ATT;
using ATT.Scripts;
using ScriptRunner.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Threading;


namespace ATT.Robot
{
    partial class Program
    {
        static void GetMessageAll() {
            MSGIDTaskData d = GetConfigData<MSGIDTaskData>();
            ScriptEngine<MSGIDTask, MSGIDTaskData> script = new ScriptEngine<MSGIDTask, MSGIDTaskData>();
            BindingStepInfo(script);
            script.StepProgress.ProgressChanged += (s, e) => { Console.WriteLine("Interface {0} Finished", e.Msg); RunTask(ATTTask.DownloadAndTransform, 0); };
            script.Run(d);
            SetConfigData(d);
        }

        static void GetMessageId() {
            MSGIDTaskData d = GetConfigData<MSGIDTaskData>();
            ScriptEngine<MSGIDTask, MSGIDTaskData> script = new ScriptEngine<MSGIDTask, MSGIDTaskData>();
            BindingStepInfo(script);
            script.StepProgress.ProgressChanged += (s, e) => Console.WriteLine("Interface {0} Finished", e.Msg);
            script.Run(d);
            SetConfigData(d);
        }

        static void TransformPayloads() {
            PayloadsData d = new PayloadsData();
            d.DownloadData = GetConfigData<PayloadsDownloaderData>();
            d.UpdateData = GetConfigData<PayloadsUpdateData>();
            d.UploadData = GetConfigData<PayloadsUploaderData>();
            ScriptEngine<Payloads, PayloadsData> script = new ScriptEngine<Payloads, PayloadsData>();
            BindingStepInfo(script);
            script.Run(d);
        }

        static void UpdatePayloads(int TaskId) {
            PayloadsUpdateData d = GetConfigData<PayloadsUpdateData>();
            d.TaskId = TaskId;
            ScriptEngine<PayloadsUpdate, PayloadsUpdateData> script = new ScriptEngine<PayloadsUpdate, PayloadsUpdateData>();
            BindingStepInfo(script);
            script.Run(d);
        }

        static void UploadPayloads(int TaskId) {
            PayloadsUploaderData d = GetConfigData<PayloadsUploaderData>();
            ScriptEngine<PayloadsUploader, PayloadsUploaderData> script = new ScriptEngine<PayloadsUploader, PayloadsUploaderData>();
            BindingStepInfo(script);
            d.TaskId = TaskId;
            script.StepProgress.ProgressChanged += (s, e) => { Console.WriteLine($"{e.Msg} sent,{e.Current} of {e.Total} finished,TaskId:{TaskId}"); };
            script.Run(d);
        }

        static void GetMessageReport() {
            PIITrackData d = GetConfigData<PIITrackData>();
            ScriptEngine<PIITrack, PIITrackData> script = new ScriptEngine<PIITrack, PIITrackData>();
            BindingStepInfo(script);
            script.Run(d);
            SetConfigData(d);
        }

        static void TrackLH() {
            LHTrackData d = GetConfigData<LHTrackData>();
            ScriptEngine<LHTrack, LHTrackData> script = new ScriptEngine<LHTrack, LHTrackData>();
            BindingStepInfo(script);
            script.Run(d);
            SetConfigData(d);
        }

        static void DownloadPayloads(int id) {
            PayloadsDownloaderData d = GetConfigData<PayloadsDownloaderData>();
            ScriptEngine<PayloadsDownloader, PayloadsDownloaderData> script = new ScriptEngine<PayloadsDownloader, PayloadsDownloaderData>();
            d.TaskId = id;
            BindingStepInfo(script);
            script.Run(d);
        }



        //static void AIFMassUpload(int id) {
        //    AIFMassUploadData d = GetAIFConfigData(id);
        //    d.TaskId = id;
        //    ScriptEngine<AIFMassUpload, AIFMassUploadData> script = new ScriptEngine<AIFMassUpload, AIFMassUploadData>();
        //    BindingStepInfo(script);
        //    script.Run(d);
        //}


        //static void ATT(Missions myMission) {
        //    Missions mission = null;
        //    using(var db = new ATTDbContext()) {
        //        mission = db.Missions.Include(m=>m.Tasks).SingleOrDefault(m => m.Id == myMission.Id);
        //        if (mission == null) {
        //            db.Missions.Add(myMission);
        //            mission = myMission;
        //        } else {
        //            foreach(var t in myMission.Tasks) {
        //                if(mission.Tasks.SingleOrDefault(s=>s.InterfaceId == t.InterfaceId) != null) {

        //                }
        //            }
        //        }
        //    }
        //}

        //static void ATTALL(Missions mission) {
        //    //List<Task> myTasks = new List<Task>();

        //    //ThreadPool.SetMinThreads(3, 3);
        //    //ThreadPool.SetMaxThreads(3, 3);

        //    //for (int i = 0; i <= 10; i++) {
        //    //    ScriptEngine<MSGIDTask, MSGIDTaskData> script = new ScriptEngine<MSGIDTask, MSGIDTaskData>();
        //    //    script.Run(_data.MsgIdTaskData);

        //    //    for (int j = 1; j <= 10; j++) {
        //    //        Task.Run(() => { }).AppendTo(myTasks);
        //    //    }
        //    //}
        //}

    }
}
