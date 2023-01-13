<?php

declare(strict_types=1);

namespace app\Api\FedbackCentr;
use Nette;
use Nette\Database\Context;

final class FeedbackApi {
    /** @var Nette\Database\Context */
    private $database;

    public function __construct(Nette\Database\Context $database) {
        $this->database = $database;
    }

    public function save($title, $feedback) {
        $this->database->table("feedback")->insert([
            "title" => $title,
            "feedback" => $feedback
        ]);
    }
}

?>