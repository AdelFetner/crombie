CREATE DATABASE crombiefy;
USE crombiefy;

-- Tabla de Usuarios
CREATE TABLE users (
    user_id INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(50) NOT NULL UNIQUE,
    email VARCHAR(100) NOT NULL UNIQUE,
    full_name VARCHAR(100),
    bio TEXT,
    profile_picture VARCHAR(255),
    date_joined TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabla de Publicaciones
CREATE TABLE posts (
    post_id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT,
    title VARCHAR(255) NOT NULL,
    content TEXT NOT NULL,
    image_url VARCHAR(255),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    is_archived BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

-- Tabla de Comentarios
CREATE TABLE comments (
    comment_id INT PRIMARY KEY AUTO_INCREMENT,
    post_id INT,
    user_id INT,
    content TEXT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (post_id) REFERENCES posts(post_id),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

-- Tabla de Me Gustas
CREATE TABLE likes (
    like_id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT,
    post_id INT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (post_id) REFERENCES posts(post_id),
    UNIQUE (user_id, post_id)
);

-- insertar data a users
INSERT INTO users (username, email, full_name, bio, profile_picture) VALUES
('johndoe', 'johndoe@example.com', 'John Doe', 'Enthusiastic coder and coffee lover.', 'https://example.com/images/johndoe.jpg'),
('janedoe', 'janedoe@example.com', 'Jane Doe', 'Nature photographer and travel enthusiast.', 'https://example.com/images/janedoe.jpg'),
('techguru', 'guru@example.com', 'Tech Guru', 'Sharing the latest in tech and innovation.', 'https://example.com/images/techguru.jpg'),
('bookworm', 'books@example.com', 'Book Worm', 'Avid reader and book reviewer.', 'https://example.com/images/bookworm.jpg'),
('artist01', 'artist@example.com', 'Creative Artist', 'Passionate about painting and digital art.', 'https://example.com/images/artist01.jpg');

-- insertar data a posts
INSERT INTO posts (user_id, title, content, image_url) VALUES
(1, 'My First Blog Post', 'This is the content of my very first blog post. Excited to share more!', 'https://example.com/images/post1.jpg'),
(2, 'Top 10 Nature Spots', 'A curated list of the best nature spots for photographers.', 'https://example.com/images/nature.jpg'),
(3, 'Tech Trends 2024', 'Exploring the trends shaping technology in 2024.', 'https://example.com/images/tech2024.jpg'),
(4, 'Review: Latest Fiction', 'Sharing my thoughts on the latest best-seller in fiction.', NULL),
(5, 'The Art of Colors', 'A deep dive into how colors influence our emotions.', 'https://example.com/images/colors.jpg');

-- insertar data a comments
INSERT INTO comments (post_id, user_id, content) VALUES
(1, 2, 'Great start! Looking forward to your next post.'),
(2, 3, 'Amazing list! I\'ve visited a few of these spots too.'),
(3, 1, 'Interesting insights! Do you think AI will dominate tech this year?'),
(4, 5, 'Loved this book too! Your review is spot on.'),
(5, 4, 'The way you explained color psychology is fascinating.');

-- insertar likes 
INSERT INTO likes (user_id, post_id) VALUES
(1, 2),
(2, 3),
(3, 5),
(4, 1),
(5, 4);

-- 1. Obtener todos los usuarios registrados
SELECT * FROM users;

-- 2. Mostrar nombres y correos de usuarios registrados en el último mes
SELECT username, email
FROM users
WHERE date_joined >= DATE_SUB(NOW(), INTERVAL 1 MONTH);

-- 3. Listar todas las publicaciones con título y fecha de creación
SELECT post_id, title, created_at
FROM posts;

-- 4. Encontrar comentarios de una publicación específica
SELECT c.comment_id, u.username, c.content, c.created_at
FROM comments c
JOIN users u ON c.user_id = u.user_id
WHERE c.post_id = 1; -- Reemplazar 1 con el ID de publicación deseado

-- 5. Crear una nueva publicación para un usuario específico
INSERT INTO posts (user_id, title, content)
VALUES (1, 'Nueva publicación', 'Contenido de la nueva publicación');

-- 6. Añadir un comentario a una publicación
INSERT INTO comments (post_id, user_id, content)
VALUES (1, 2, 'Nuevo comentario en esta publicación');

-- 7. Cambiar la fecha de un comentario a la fecha actual
UPDATE comments
SET created_at = NOW()
WHERE comment_id = 1;

-- 8. Incrementar likes de una publicación
INSERT INTO likes (user_id, post_id)
VALUES (3, 2);

-- 9. Marcar una publicación como archivada
UPDATE posts
SET is_archived = TRUE
WHERE post_id = 1;