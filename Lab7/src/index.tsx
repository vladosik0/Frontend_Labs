import React from "react";
import ReactDOM from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";

import App from "./App";
import Task1 from "./components/task1";
import Task2 from "./components/task2";

const router = createBrowserRouter([
  {
    path: "/",
    Component: App,
  },
  {
    path: "/task1",
    Component: Task1,
  },
  {
    path: "/task2",
    Component: Task2,
  },
]);

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);

root.render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);

