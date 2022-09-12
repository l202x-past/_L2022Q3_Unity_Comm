using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 아래의 System.IO.Ports를 사용하기 위해서는
 * Unity Editor > Edit > Project Settings > Player > Other Settings > Configuration > Api Compatibility Level을
 * .NET 4.x로 설정하고 Unity Editor를 다시 시작해야 함 * 
 */
using System.IO.Ports;

using System; // catch exception 처리를 위해 사용

/*
Arduino Code
------------- 
int value1 = 0;
int value2 = 0;
String strings[] = {"string1", "string2", "string3"};
int stringIndex = 0;
String value3 = strings[stringIndex];

void setup() {
  Serial.begin(9600);
}

void loop() {
  Serial.print(value1);
  Serial.print(",");
  Serial.print(value2);
  Serial.print(",");
  Serial.print(value3);
  Serial.println();

  value1++;
  value2 = value1*2;
  stringIndex = random(3);
  value3 = strings[stringIndex];

  delay(1000);
}
------------- 
*/

public class Serial_Read_Delimiter : MonoBehaviour
{
    /// <summary>
    /// 시리얼 통신을 담당하는 arduino 객체 생성
    /// </summary>
    SerialPort arduino;

    /// <summary>
    /// 시리얼 포트
    /// </summary>
    public string portName = "COM5";

    /// <summary>
    /// 아두이노가 보내는 데이터를 저장하는 sting 변수
    /// </summary>
    public string serialIn;

    /// <summary>
    /// 아두이노가 보내는 데이터의 수 (구분자 기준)
    /// </summary>
    public int dataCount = 3;

    // Start is called before the first frame update
    void Start()
    {
        ///
        // PC에 활성화된 시리얼 포트의 목록 추출
        ///
        string[] ports = SerialPort.GetPortNames();

        ///
        // ports 배열 안에 있는 각 요소(가령, port)를 출력
        foreach (string port in ports)
        {
            print(port);
        }

        ///
        // arduino 객체를 포트 이름, 통신 속도에 맞춰 초기화
        ///
        arduino = new SerialPort(portName.ToString(), 9600);

        ///
        // arduino 포트 개방
        ///
        arduino.Open();
    }

    // Update is called once per frame
    void Update()
    {
        if (arduino.IsOpen)
        {
            try
            {
                serialIn = arduino.ReadLine();
                print("raw:" + serialIn);
                if (serialIn != null)
                {
                    serialIn = serialIn.Trim();
                    print("trimmed:" + serialIn);

                    string[] serialData = serialIn.Split(',');
                    if(serialData.Length == dataCount)
                    {
                        int data1 = int.Parse(serialData[0]);
                        int data2 = int.Parse(serialData[1]);
                        string data3 = serialData[2];
                        print($"serial data = {data1}, {data2}, {data3}");
                    }
                }
            }
            catch (Exception e)
            {
                print(e);
            }
        }

    }
    void OnApplicationQuit()
    {
        arduino.Close();
    }
}

