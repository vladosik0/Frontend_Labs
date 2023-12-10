import { useState } from "react";


const Image = () => {
  const [toShowImage, setToShowImage] = useState(false);
  const [imageWidth, setImageWidth] = useState(400);

  const increaseSizeOfImage = () => {
    if (imageWidth <= 1000) {
      setImageWidth((prev) => prev + 50);
    }
  };

  const decreaseSizeOfImage = () => {
    if (imageWidth > 50) {
      setImageWidth((prev) => prev - 50);
    }
  };

  return (
    <>
      <div>
        <p>
          Ки́їв — столиця та найбільше місто України. Розташований у середній
          течії Дніпра, у північній Наддніпрянщині. Політичний,
          соціально-економічний, транспортний, освітньо-науковий, історичний,
          культурний та духовний центр України. У системі
          адміністративно-територіального устрою України Київ має спеціальний
          статус, визначений Конституцією, і не входить до складу жодної
          області, хоча і є адміністративним центром Київської області. Місце
          розташування центральних органів влади України, іноземних місій,
          штаб-квартир більшості підприємств і громадських об'єднань, що
          працюють в Україні.
        </p>
        <a href="https://kyivcity.gov.ua/">
          <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/4/49/17-07-02-Maidan_Nezalezhnosti_RR74377-PANORAMA.jpg/1920px-17-07-02-Maidan_Nezalezhnosti_RR74377-PANORAMA.jpg"
           alt="Kyiv"
           width="400"/>
        </a>
      </div>
      {toShowImage && <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/4/49/17-07-02-Maidan_Nezalezhnosti_RR74377-PANORAMA.jpg/1920px-17-07-02-Maidan_Nezalezhnosti_RR74377-PANORAMA.jpg"
           alt="Kyiv"
           width={imageWidth} />}
      <div className="mt-3">
        <button onClick={() => setToShowImage(true)}>Додати</button>
        <button onClick={increaseSizeOfImage}>Збільшити</button>
        <button onClick={decreaseSizeOfImage}>Зменшити</button>
        <button onClick={() => setToShowImage(false)}>Видалити</button>
      </div>
    </>
  );
};

export default Image;