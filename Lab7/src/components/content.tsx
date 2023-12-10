import React from "react";

class Content extends React.Component {
  render(): React.ReactNode {
    return (
      <>
        <div>
          <p>Мої хобі:</p>
          <ul>
            <li>Спорт</li>
            <li>Відеоігри</li>
            <li>Перегляд футбольних матчів</li>
          </ul>
        </div>
        <div>
          <p>Улюблені фільми:</p>
          <ol>
            <div>
                <li>Форест Гамп</li>
            </div>
            <div>
                <li>Зелена книга</li>
            </div>
            <li>Втеча з Шоушенка</li>
          </ol>
        </div>
      </>
    );
  }
}

export default Content;