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
    /// �ø��� ����� ����ϴ� arduino ��ü ����
    /// </summary>
    SerialPort arduino;

    /// <summary>
    /// �ø��� ��Ʈ
    /// </summary>
    public string portName = "COM5";

    /// <summary>
    /// �Ƶ��̳밡 ������ �����͸� �����ϴ� sting ����
    /// </summary>
    public string serialIn;

    /// <summary>
    /// �Ƶ��̳밡 ������ �������� �� (������ ����)
    /// </summary>
    public int dataCount = 3;

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

