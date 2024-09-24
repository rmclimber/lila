import React, { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./styles.css";

import App from "./App";

const root = createRoot(document.getElementById("app_pane"));
root.render(
  <StrictMode>
    <App />
  </StrictMode>
);