using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * �Ʒ��� System.IO.Ports�� ����ϱ� ���ؼ���
 * Unity Editor > Edit > Project Settings > Player > Other Settings > Configuration > Api Compatibility Level��
 * .NET 4.x�� �����ϰ� Unity Editor�� �ٽ� �����ؾ� �� * 
 */
using System.IO.Ports;

using System; // catch exception ó���� ���� ���

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
    /// �ø��� ����� ����ϴ� arduino ��ü ����
    /// </summary>
    SerialPort arduino;

    /// <summary>
    /// �ø��� ��Ʈ
    /// </summary>
    public string portName = "COM5";

    /// <summary>
    /// �Ƶ��̳�� ������ �����͸� �����ϴ� sting ����
    /// </summary>
    //public string serialOut;

    /// <summary>
    /// �Ƶ��̳�� ������ �����͸� �����ϴ� sting ����
    /// </summary>
    //public int value = 0;

    // Start is called before the first frame update
    void Start()
    {
        ///
        // PC�� Ȱ��ȭ�� �ø��� ��Ʈ�� ��� ����
        ///
        string[] ports = SerialPort.GetPortNames();

        ///
        // ports �迭 �ȿ� �ִ� �� ���(����, port)�� ���
        foreach (string port in ports)
        {
            print(port);
        }

        ///
        // arduino ��ü�� ��Ʈ �̸�, ��� �ӵ��� ���� �ʱ�ȭ
        ///
        arduino = new SerialPort(portName.ToString(), 9600);

        ///
        // arduino ��Ʈ ����
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


