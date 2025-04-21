using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class TrapManager : MonoBehaviour
{
    // Dictionary เก็บ trap แต่ละด่าน
    public Dictionary<string, List<string>> levelTrapMap = new Dictionary<string, List<string>>()
    {
        { "Level_1", new List<string> { "000000", "00000" } },
        { "Level_2", new List<string> { "000000", "00000" } },
        { "Level_3", new List<string> { "000000", "00000" } },
        { "Level_4", new List<string> { "000000", "00000" } },
    };

    // ตัวแปรนับจำนวนการโดนกับดักในแต่ละ level
    private Dictionary<string, int> trapHitCount = new Dictionary<string, int>();

    // เรียกเมื่อเริ่มเกม
    private async void Start()
    {
        // เริ่มต้น Unity Services + Analytics
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();

        // ลองแสดง trap แต่ละ level ดูใน Console (ตอนเริ่มเกม)
        PrintAllTrapsInAllLevels();
    }

    // เมื่อเข้าสู่ level ใหม่
    public void EnterLevel(string levelName)
    {
        // ตรวจสอบว่ามี key ใน Dictionary หรือไม่ ถ้ายังไม่มีให้สร้าง
        if (!trapHitCount.ContainsKey(levelName))
        {
            trapHitCount[levelName] = 0;  // ตั้งค่าจำนวนครั้งที่โดนใน level เป็น 0
        }

        // แสดง trap ของ level นั้นใน Console
        PrintTrapsInLevel(levelName);
    }

    // ฟังก์ชันที่แสดง trap ของ level ที่กำหนด
    private void PrintTrapsInLevel(string levelName)
    {
        if (levelTrapMap.ContainsKey(levelName))
        {
            string traps = string.Join(", ", levelTrapMap[levelName]);
            Debug.Log($"{levelName} มี trap: {traps}");
        }
        else
        {
            Debug.Log($"ไม่พบข้อมูล trap สำหรับ {levelName}");
        }
    }

    // ฟังก์ชันสำหรับส่งข้อมูลเมื่อผู้เล่นโดน trap
    public void PlayerHitTrap(string levelName, string trapType)
    {
        // เพิ่มจำนวนการโดนกับดักใน level นั้น
        if (trapHitCount.ContainsKey(levelName))
        {
            trapHitCount[levelName]++;
        }

        // ส่ง event ไปยัง Unity Analytics
        AnalyticsService.Instance.CustomData("Trap_Hit", new()
        {
            { "level", levelName },
            { "trapType", trapType },
            { "hitCount", trapHitCount[levelName] }  // ส่งข้อมูลจำนวนครั้งที่โดน
        });

        Debug.Log($"บันทึก Analytics: Level = {levelName}, Trap = {trapType}, Hit Count = {trapHitCount[levelName]}");
    }

    // แสดง trap ที่มีในแต่ละด่าน (ตอนเริ่มเกม)
    private void PrintAllTrapsInAllLevels()
    {
        Debug.Log("Trap ที่มีในแต่ละ Level:");
        foreach (var entry in levelTrapMap)
        {
            string level = entry.Key;
            string traps = string.Join(", ", entry.Value);
            Debug.Log($"{level} มี trap: {traps}");
        }
    }

    // แสดงจำนวนครั้งที่โดนกับดักในแต่ละ level
    public void PrintHitCount(string levelName)
    {
        if (trapHitCount.ContainsKey(levelName))
        {
            Debug.Log($"จำนวนครั้งที่โดนกับดักใน {levelName}: {trapHitCount[levelName]} ครั้ง");
        }
        else
        {
            Debug.Log($"ยังไม่มีการนับจำนวนการโดนกับดักใน {levelName}");
        }
    }
}
