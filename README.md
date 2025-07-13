
# TarotAppV2

A modern, intuitive Tarot card reading application designed to provide users with insightful and personalized Tarot readings through an engaging and user-friendly interface.

---

## Table of Contents

- [Project Overview](#project-overview)  
- [Features](#features)  
- [Technology Stack](#technology-stack)  
- [Getting Started](#getting-started)  
- [Running the Application](#running-the-application)  
- [Usage](#usage)  
- [Folder Structure](#folder-structure)  
- [Contributing](#contributing)  
- [License & Contact](#license--contact)  

---

## Project Overview

TarotAppV2 is a full-stack application designed to offer users authentic Tarot card readings based on traditional Tarot decks. It features a visually appealing front-end with smooth animations and dynamic card selection, backed by a robust API that manages Tarot card data and user sessions. The application supports multiple Tarot spreads, personalized daily readings, and detailed card meanings to enrich the user’s experience. It is built with scalability and responsiveness in mind, ensuring compatibility across devices.

---

## Features

- User-friendly interface with beautiful card animations and intuitive UX  
- Multiple Tarot spreads (Three-Card, Celtic Cross, custom)  
- Personalized daily Tarot readings  
- Detailed card meanings and symbolism  
- Optional user authentication for saving history and preferences  
- Responsive design for mobile, tablet, and desktop  
- Interactive card shuffling and drawing with dynamic effects  
- History and favorites management  
- Admin panel for managing decks, card data, and users (optional)  
- Secure backend API with authentication and error handling  

---

## Technology Stack

**Frontend:** React.js, Redux, React Router, Tailwind CSS, Framer Motion  
**Backend:** Node.js, Express.js  
**Database:** MongoDB, Mongoose  
**Authentication:** JSON Web Token (JWT), bcrypt  
**Animations:** Framer Motion  
**Testing:** Jest, Supertest  

---

## Getting Started & Running the Application

1. Clone the repository and install dependencies:

```bash
git clone https://github.com/burakcanheyal/TarotAppV2.git
cd TarotAppV2/backend
npm install
cd ../frontend
npm install
```

2. Create a `.env` file inside the `backend` folder with these variables:

```
PORT=5000
MONGO_URI=your_mongodb_connection_string
JWT_SECRET=your_jwt_secret
NODE_ENV=development
```

3. Start backend and frontend servers separately:

- Backend:

```bash
cd backend
npm run dev
```

- Frontend:

```bash
cd ../frontend
npm start
```

Backend will run on `http://localhost:5000` and frontend on `http://localhost:3000`.

---

## Usage

Open the app in your browser, choose a Tarot spread or a daily reading, shuffle and draw cards interactively, view detailed card interpretations, optionally register/login to save readings and preferences, and explore saved history and favorites.

---

## Folder Structure

```
TarotAppV2/
├── backend/                  # Node.js + Express backend
│   ├── controllers/          # API route logic
│   ├── models/               # MongoDB schemas
│   ├── routes/               # API endpoints
│   ├── middleware/           # Auth & error handling
│   ├── config/               # DB and environment configs
│   ├── utils/                # Helper functions
│   ├── tests/                # Backend tests
│   ├── server.js             # Backend entry point
│   └── package.json
├── frontend/                 # React frontend app
│   ├── public/               # Static assets
│   ├── src/
│   │   ├── components/       # Reusable UI components
│   │   ├── pages/            # Route components
│   │   ├── redux/            # State management (slices, store)
│   │   ├── services/         # API service calls
│   │   ├── styles/           # Tailwind CSS and custom styles
│   │   ├── utils/            # Helpers/utilities
│   │   ├── App.js            # Main React component
│   │   └── index.js          # React entry point
│   └── package.json
├── docs/                     # Documentation files (optional)
├── README.md                 # This file
└── .gitignore
```

---

## Contributing

Fork the repo, create a new branch (`git checkout -b feature/your-feature`), commit your changes (`git commit -m "Add feature"`), push (`git push origin feature/your-feature`), and open a pull request. Please keep code style consistent and add tests when relevant.

---

## License & Contact

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

For questions or collaboration, contact:

**Burak Can Heyal**  
Email: burakcanheyal@gmail.com  
GitHub: https://github.com/burakcanheyal

---

Thank you for checking out TarotAppV2! 🌟
