-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Jan 25. 08:41
-- Kiszolgáló verziója: 10.4.22-MariaDB
-- PHP verzió: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `lakopark`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `adatok`
--

CREATE TABLE `adatok` (
  `nev` varchar(255) NOT NULL,
  `dimenzio` varchar(255) NOT NULL,
  `hazak` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `adatok`
--

INSERT INTO `adatok` (`nev`, `dimenzio`, `hazak`) VALUES
('Puskás Ferenc', '5;10', '1,1,2;1,2,1;1,3,1;1,6,3;1,7,1;2,2,1;2,3,2;2,6,2;2,8,2;3,2,1;3,3,3;3,4,1;3,5,3;3,6,2;3,7,1;3,8,1;4,3,2;4,5,3;4,6,2;4,8,3;4,9,3;5,1,1;5,4,1;5,7,1;5,8,3');
COMMIT;

INSERT INTO `adatok` (`nev`, `dimenzio`, `hazak`) VALUES
('Van Gogh', '3;5', '1,1,1;1,3,3;1,5,2;2,1,3;2,3,3;2,4,3;2,5,2;3,1,1;3,2,3;3,5,2');
COMMIT;

INSERT INTO `adatok` (`nev`, `dimenzio`, `hazak`) VALUES
('Vivaldi', '4;7', '1,2,3;1,3,1;1,7,3;2,1,2;2,2,2;2,3,3;2,7,2;3,2,1;3,5,1;3,6,1;3,7,3;4,1,2;4,2,3;4,3,2;4,5,3;4,6,3');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
