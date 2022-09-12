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
int ledPins[] = {12, 13};
int numLedPins = 2;

void setup() {
  Serial.begin(9600);
  for (int i = 0; i < numLedPins; i++) {
    pinMode(ledPins[i], OUTPUT);
  }
}

void loop() {
  if (Serial.available()) {
    char c = Serial.read();
    Serial.println(c);
    if (c != 10 && c != 13) {
      if (c == '0') {
        for (int i = 0; i < numLedPins; i++) {
          digitalWrite(ledPins[i], LOW);
        }
      } else if (c == '5') {
        for (int i = 0; i < numLedPins; i++) {
          digitalWrite(ledPins[i], HIGH);
        }
      } else if (c > '0' && c <= numLedPins + '0') {
        for (int i = 0; i < numLedPins; i++) {
          digitalWrite(ledPins[i], LOW);
        }
        int index = c - '1';
        digitalWrite(ledPins[index], HIGH);
        Serial.println(index);
      } else {
        for (int i = 0; i < numLedPins; i++) {
          digitalWrite(ledPins[i], LOW);
        }
      }
    }
  }
}
------------- 
*/

public class Serial_Write_Buttons : MonoBehaviour
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
    /// 아두이노로 보내는 데이터를 저장하는 sting 변수
    /// </summary>
    //public string serialOut;

    /// <summary>
    /// 아두이노로 보내는 데이터를 저장하는 sting 변수
    /// </summary>
    //public int value = 0;

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

    }
    void OnApplicationQuit()
    {
        arduino.Close();
    }

    public void SimpleWrite(string value)
    {
        arduino.WriteLine(value + "\n");
    }
}


